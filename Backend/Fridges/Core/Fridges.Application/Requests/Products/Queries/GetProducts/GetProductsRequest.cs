using Fridges.Domain;
using MediatR;

namespace Fridges.Application.Requests.Products.Queries.GetProducts;

public record GetProductsRequest(int Page) : IRequest<List<Product>>;
    
