
using AlertMedicament.Domain.Entities;
using Hangfire.PostgreSql.Properties;
using Microsoft.EntityFrameworkCore;

namespace AlertMedicament.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets
      public DbSet<Medicine> Medicines { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
