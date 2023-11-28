using Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;
using Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModel;
using Fridges.Application.Requests.FridgeModels.Queries.GetFridgeModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fridges.ServiceHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeModelController(ISender sender) : ControllerBase
{
    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetFridgeModels(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeModelsRequest(page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeModelRequest(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFridgeModel(
        [FromBody] CreateFridgeModelRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeModel), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeModelRequest(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeModel(
        UpdateFridgeModelRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeModel), new { id = response.Id }, response);
    }
}