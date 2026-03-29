namespace AlertMedicament.Application.Features.Medicines;

public record CreateMedicineResponse(
    int Id,
    string Name,
    int MinimumStock,
    int MaximumStock,
    string? Description,
    bool RequiresPrescription,
    DateTime CreatedAt
);