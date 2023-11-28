using Fridges.Application.Services;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence.Services;

public class ManufactureRepository(FridgesDbContext fridgesDbContext) : IManufactureRepository
{
    public async Task<List<Manufacture>> GetManufacturesAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await fridgesDbContext.Manufactures
            .AsQueryable()
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Manufacture?> GetManufactureAsync(Guid id, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .Manufactures
            .FirstOrDefaultAsync(manufacture => manufacture.Id == id, cancellationToken);
    }
    
    public async Task<List<FridgeModel>> GetManufactureModelsAsync(Guid id, int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .Manufactures
            .AsQueryable()
            .Where(manufacture => manufacture.Id == id)
            .Include(manufacture => manufacture.FridgeModels)
            .SelectMany(manufacture => manufacture.FridgeModels)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<Manufacture> CreateManufactureAsync(Manufacture manufacture, CancellationToken cancellationToken)
    {
        var entry = await fridgesDbContext.Manufactures.AddAsync(manufacture, cancellationToken);
        return entry.Entity;
    }

    public Manufacture UpdateManufacture(Manufacture manufacture)
    {
        return fridgesDbContext.Manufactures.Update(manufacture).Entity;
    }

    public void DeleteManufacture(Manufacture manufacture)
    {
        fridgesDbContext.Manufactures.Remove(manufacture);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await fridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}