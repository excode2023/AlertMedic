using AlertMedicament.Application.Interfaces.Persistence;
using AlertMedicament.Domain.Entities;
using AlertMedicament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AlertMedicament.Infrastructure.Persistence.Repositories;

public class MedicineRepository : IMedicineRepository
{
    private readonly AppDbContext _context;

    public MedicineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Medicine medicine)
    {
        await _context.Medicines.AddAsync(medicine);
        await _context.SaveChangesAsync();
    }
}