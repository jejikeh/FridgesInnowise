using Fridges.Domain;

namespace Fridges.Application.Services;

public interface IProductRepository
{
    public Task<List<Product>> GetProductAsync(
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken);
    
    public Task<Product?> GetProductAsync(
        Guid id, 
        CancellationToken cancellationToken);
    
    public Task<Product> CreateProductAsync(
        Product product, 
        CancellationToken cancellationToken);
    
    public Product UpdateProduct(Product product);
    public void DeleteProduct(Product product);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}