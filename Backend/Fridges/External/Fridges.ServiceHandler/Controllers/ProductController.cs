using Fridges.Application.Requests.Products.Commands.CreateProduct;
using Fridges.Application.Requests.Products.Commands.DeleteProduct;
using Fridges.Application.Requests.Products.Commands.UpdateProduct;
using Fridges.Application.Requests.Products.Queries.GetProduct;
using Fridges.Application.Requests.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fridges.ServiceHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ISender sender) : ControllerBase
{
    [HttpGet("{page:int}")]
    public async Task<IActionResult> GetProducts(
        int page,
        CancellationToken cancellationToken)
    {
        var command = new GetProductsCommand(page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductCommand(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }
}