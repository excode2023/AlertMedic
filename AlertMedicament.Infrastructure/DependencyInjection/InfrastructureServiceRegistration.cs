using AlertMedicament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AlertMedicament.Application.Interfaces.Persistence;
using AlertMedicament.Infrastructure.Persistence.Repositories;

namespace AlertMedicament.Infrastructure.DependencyInjection;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // PostgreSQL con EF Core
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            ));

        
        services.AddScoped<IMedicineRepository, MedicineRepository>();

        return services;
    }
}
// este archivo se encarga de registrar los servicios relacionados con la infraestructura, 
//como la configuración de la base de datos utilizando Entity Framework Core con PostgreSQL. 
// También se registra el repositorio de medicamentos para que pueda ser inyectado en otras partes de la aplicación.    
//para usar este método, simplemente llámalo desde el método ConfigureServices en tu clase Startup.cs o Program.cs, pasando la configuración de la aplicación.  