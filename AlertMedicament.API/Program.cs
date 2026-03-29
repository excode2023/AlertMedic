using AlertMedicament.Application.DependencyInjection;
using AlertMedicament.Infrastructure.DependencyInjection;
using Scalar.AspNetCore;  

var builder = WebApplication.CreateBuilder(args);

// =============================================
// 1. Servicios de Aplicación
// =============================================
builder.Services.AddApplicationServices();

// =============================================
// 2. Servicios de Infraestructura
// =============================================
builder.Services.AddInfrastructureServices(builder.Configuration);

// =============================================
// 3. Configuración de la API
// =============================================
builder.Services.AddControllers();
builder.Services.AddOpenApi();           // Necesario para generar el JSON OpenAPI

var app = builder.Build();

// =============================================
// 4. Pipeline - SOLO Scalar (como querías)
// =============================================
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // Expone el archivo OpenAPI en /openapi/v1.json

    // Scalar - Configuración oficial
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("AlertMedicament API")
            .WithTheme(ScalarTheme.DeepSpace)     // Tema oscuro profesional
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

    // Redirección automática de la raíz a Scalar
    app.MapGet("/", () => Results.Redirect("/scalar"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();