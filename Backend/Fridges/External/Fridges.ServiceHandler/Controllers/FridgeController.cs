using Fridges.Application.Requests.Fridges.Commands.CreateFridge;
using Fridges.Application.Requests.Fridges.Commands.DeleteFridge;
using Fridges.Application.Requests.Fridges.Commands.UpdateFridge;
using Fridges.Application.Requests.Fridges.Queries.GetFridge;
using Fridges.Application.Requests.Fridges.Queries.GetFridges;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fridges.ServiceHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeController(ISender sender) : ControllerBase
{
    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetFridges(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgesRequest(page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridge(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeRequest(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFridgeModel(
        CreateFridgeRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetFridge), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeModel(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeRequest(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeModel(
        UpdateFridgeRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridge), new { id = response.Id }, response);
    }
}