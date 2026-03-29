using AlertMedicament.Application.Features.Medicines;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlertMedicament.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicinesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Crea un nuevo medicamento en el sistema
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicineCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
    }
}