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
        var command = new GetProductsRequest(page);
        var response = await sender.Send(command, cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductRequest(id);
        var response = await sender.Send(command, cancellationToken);
        
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        CreateProductRequest request,
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
        var command = new DeleteProductRequest(id);
        await sender.Send(command, cancellationToken);
        
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(
        UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var response = await sender.Send(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }
}