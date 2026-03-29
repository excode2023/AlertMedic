using AlertMedicament.Domain.Entities;

namespace AlertMedicament.Application.Interfaces.Persistence;

public interface IMedicineRepository
{
    Task AddAsync(Medicine medicine);
    // Más métodos vendrán después: GetById, GetAll, Update, etc.
}