using Fridges.Application.Services;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence.Services;

public class FridgeRepository(FridgesDbContext fridgesDbContext) : IFridgeRepository
{
    public async Task<List<Fridge>> GetFridgesAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await fridgesDbContext.Fridges
            .AsQueryable()
            .Include(fridge => fridge.FridgeProducts)
            .Include(fridge => fridge.Model)
            .ThenInclude(model => model.Manufacture)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Fridge?> GetFridgeAsync(Guid id, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .Fridges
            .AsQueryable()
            .Include(fridge => fridge.FridgeProducts)
            .Include(fridge => fridge.Model)
            .ThenInclude(model => model!.Manufacture)
            .AsNoTracking()
            .FirstOrDefaultAsync(fridge => fridge.Id == id, cancellationToken);
    }

    public async Task<Fridge> CreateFridgeAsync(Fridge fridge, CancellationToken cancellationToken)
    {
        var entity = await fridgesDbContext
            .Fridges
            .AddAsync(fridge, cancellationToken);
        
        return entity.Entity;
    }

    public Fridge UpdateFridge(Fridge fridge)
    {
        return fridgesDbContext.Fridges.Update(fridge).Entity;
    }

    public void DeleteFridge(Fridge fridge)
    {
        fridgesDbContext.Fridges.Remove(fridge);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await fridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}