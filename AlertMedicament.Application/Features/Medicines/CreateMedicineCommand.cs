using AlertMedicament.Application.Features.Medicines;
using MediatR;

namespace AlertMedicament.Application.Features.Medicines;

public record CreateMedicineCommand(
    string Name,
    int MinimumStock,
    int MaximumStock,
    string? Description = null,
    bool RequiresPrescription = false
) : IRequest<CreateMedicineResponse>;