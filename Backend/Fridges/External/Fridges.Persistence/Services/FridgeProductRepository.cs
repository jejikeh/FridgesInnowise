using Fridges.Application.Services;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence.Services;

public class FridgeProductRepository(FridgesDbContext fridgesDbContext) : IFridgeProductRepository
{
    public async Task<List<FridgeProduct>> GetFridgeProductsAsync(
        Guid fridgeId, 
        int skipCount, 
        int takeCount, 
        CancellationToken cancellationToken)
    {
        return await fridgesDbContext.FridgeProducts
            .AsQueryable()
            .Where(product => product.FridgeId == fridgeId)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<FridgeProduct?> GetFridgeProductAsync(Guid id, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .FridgeProducts
            .FirstOrDefaultAsync(fridgeProduct => fridgeProduct.Id == id, cancellationToken);
    }

    public async Task<FridgeProduct> CreateFridgeProductAsync(FridgeProduct fridgeProduct, CancellationToken cancellationToken)
    {
        var entityEntry = await fridgesDbContext.FridgeProducts.AddAsync(fridgeProduct, cancellationToken);
        return entityEntry.Entity;
    }

    public FridgeProduct UpdateFridgeProduct(FridgeProduct fridgeProduct)
    {
        return fridgesDbContext.FridgeProducts.Update(fridgeProduct).Entity;
    }

    public void DeleteFridgeProduct(FridgeProduct fridgeProduct)
    {
        fridgesDbContext.FridgeProducts.Remove(fridgeProduct);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await fridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}