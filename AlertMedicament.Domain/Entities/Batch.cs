using AlertMedicament.Domain.Common;

namespace AlertMedicament.Domain.Entities;

public class Batch : BaseEntity<int>
{
    public int MedicineId { get; private set; }
    public string BatchNumber { get; private set; } = string.Empty;
    public DateTime ExpirationDate { get; private set; }
    public int Quantity { get; private set; }

    // Relación de navegación
    public Medicine Medicine { get; private set; } = null!;

    // Constructor protegido para EF Core
    protected Batch() { }

    // Constructor con reglas de dominio
    public Batch(string batchNumber, DateTime expirationDate, int quantity, int medicineId)
    {
        if (string.IsNullOrWhiteSpace(batchNumber))
            throw new ArgumentException("El número de lote es obligatorio.", nameof(batchNumber));

        if (quantity < 0)
            throw new ArgumentException("La cantidad no puede ser negativa.", nameof(quantity));

        if (expirationDate <= DateTime.UtcNow)
            throw new ArgumentException("La fecha de caducidad debe ser futura.", nameof(expirationDate));

        BatchNumber = batchNumber.Trim();
        ExpirationDate = expirationDate;
        Quantity = quantity;
        MedicineId = medicineId;
    }

    // Método para actualizar cantidad (regla de dominio)
    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("La cantidad no puede ser negativa.");

        Quantity = newQuantity;
        UpdateTimestamp();
    }
}

//este archivo define la entidad Batch, que representa un lote de medicamentos,
// con propiedades como el número de lote, fecha de caducidad, 
//cantidad y una relación con la entidad Medicine. 
//También incluye reglas de dominio para validar los datos al crear o actualizar un lote.
