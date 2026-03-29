using AlertMedicament.Domain.Common;

namespace AlertMedicament.Domain.Entities;

public class Medicine : BaseEntity<int>
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public int MinimumStock { get; private set; }
    public int MaximumStock { get; private set; }
    public bool RequiresPrescription { get; private set; }

    // Relación One-to-Many con Batch
    public ICollection<Batch> Batches { get; private set; } = new List<Batch>();

    // Constructor protegido para EF Core
    protected Medicine() { }

    // Constructor con reglas de dominio
    public Medicine(string name, int minStock, int maxStock, string? description = null, bool requiresPrescription = false)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del medicamento es obligatorio.", nameof(name));

        if (minStock < 0)
            throw new ArgumentException("El stock mínimo no puede ser negativo.", nameof(minStock));

        if (maxStock <= minStock)
            throw new ArgumentException("El stock máximo debe ser mayor que el stock mínimo.", nameof(maxStock));

        Name = name.Trim();
        Description = description?.Trim();
        MinimumStock = minStock;
        MaximumStock = maxStock;
        RequiresPrescription = requiresPrescription;
    }

    // Método para agregar un lote (regla de dominio)
    public void AddBatch(Batch batch)
    {
        if (batch == null)
            throw new ArgumentNullException(nameof(batch));

        Batches.Add(batch);
        UpdateTimestamp();
    }
}