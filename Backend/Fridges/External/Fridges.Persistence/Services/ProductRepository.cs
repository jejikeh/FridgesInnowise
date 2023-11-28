using Fridges.Application.Services;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence.Services;

public class ProductRepository(FridgesDbContext fridgesDbContext) : IProductRepository
{
    public async Task<List<Product>> GetProductAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await fridgesDbContext.Products
            .AsQueryable()
            .Include(product => product.FridgeProducts)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetProductAsync(Guid id, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .Products
            .AsQueryable()
            .Include(product => product.FridgeProducts)
            .FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
    }

    public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        var entityEntry = await fridgesDbContext.Products.AddAsync(product, cancellationToken);
        return entityEntry.Entity;
    }

    public Product UpdateProduct(Product product)
    {
        return fridgesDbContext.Products.Update(product).Entity;
    }

    public void DeleteProduct(Product product)
    {
        fridgesDbContext.Products.Remove(product);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await fridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}