using AlertMedicament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlertMedicament.Infrastructure.Persistence.Configurations;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.Description)
               .HasMaxLength(500);

        builder.Property(m => m.MinimumStock)
               .IsRequired();

        builder.Property(m => m.MaximumStock)
               .IsRequired();

        // Relación con Batches
        builder.HasMany(m => m.Batches)
               .WithOne(b => b.Medicine)
               .HasForeignKey(b => b.MedicineId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}