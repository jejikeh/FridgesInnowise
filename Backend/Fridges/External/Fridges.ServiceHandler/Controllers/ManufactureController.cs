using Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;
using Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;
using Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;
using Fridges.Application.Requests.Manufactures.Queries.GetManufacture;
using Fridges.Application.Requests.Manufactures.Queries.GetManufactureModels;
using Fridges.Application.Requests.Manufactures.Queries.GetManufactures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fridges.ServiceHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufactureController(ISender sender) : ControllerBase
{
    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetManufactures(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetManufacturesRequest(page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetManufacture(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetManufactureRequest(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpGet("{id:guid}/{page:int}")]
    public async Task<IActionResult> GetManufactureModels(
        Guid id,
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetManufactureModelsRequest(id, page);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateManufacture(
        CreateManufactureRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetManufacture), new { id = response.Id }, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManufacture(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteManufactureRequest(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateManufacture(
        UpdateManufactureRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetManufacture), new { id = response.Id }, response);
    }
}