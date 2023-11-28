using Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Queries.GetFridgeProducts;
using Fridges.Application.Requests.Products.Commands.CreateProduct;
using Fridges.Application.Requests.Products.Commands.DeleteProduct;
using Fridges.Application.Requests.Products.Commands.UpdateProduct;
using Fridges.Application.Requests.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fridges.ServiceHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeProductController(ISender sender) : ControllerBase
{
    [HttpGet("fridge/{fridgeId:guid}/{page:int}")]
    public async Task<IActionResult> GetFridgeProducts(
        Guid fridgeId,
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetFridgeProductsRequest(fridgeId, page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetFridgeProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductRequest(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFridgeProduct(
        CreateFridgeProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeProduct), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFridgeProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteFridgeProductRequest(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFridgeProduct(
        UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetFridgeProducts), new { id = response.Id }, response);
    }
}