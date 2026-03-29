using AlertMedicament.Application.Features.Medicines;
using AlertMedicament.Domain.Entities;
using AlertMedicament.Application.Interfaces.Persistence;   // ← Nueva interfaz
using MediatR;

namespace AlertMedicament.Application.Features.Medicines;

public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommand, CreateMedicineResponse>
{
    private readonly IMedicineRepository _medicineRepository;

    public CreateMedicineCommandHandler(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public async Task<CreateMedicineResponse> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
    {
        // Crear la entidad de dominio (reglas de negocio)
        var medicine = new Medicine(
            request.Name,
            request.MinimumStock,
            request.MaximumStock,
            request.Description,
            request.RequiresPrescription
        );

        // Guardar usando el repositorio (abstracción)
        await _medicineRepository.AddAsync(medicine);

        // Retornar respuesta
        return new CreateMedicineResponse(
            medicine.Id,
            medicine.Name,
            medicine.MinimumStock,
            medicine.MaximumStock,
            medicine.Description,
            medicine.RequiresPrescription,
            medicine.CreatedAt
        );
    }
}