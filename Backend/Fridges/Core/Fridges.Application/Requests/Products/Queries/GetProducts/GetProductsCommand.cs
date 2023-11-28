using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProducts;

public record GetProductsCommand(int Page) : IRequest<List<Product>>;
    
