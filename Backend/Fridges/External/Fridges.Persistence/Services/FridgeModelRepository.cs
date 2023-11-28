using Fridges.Application.Services;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence.Services;

public class FridgeModelRepository(FridgesDbContext fridgesDbContext) : IFridgeModelsRepository
{
    public async Task<List<FridgeModel>> GetFridgeModelsAsync(int skipCount, int takeCount, CancellationToken cancellationToken)
    {
        return await fridgesDbContext.FridgeModels
            .AsQueryable()
            .OrderBy(data => data.Name)
            .Include(data => data.Manufacture)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync(cancellationToken);
    }

    public async Task<FridgeModel?> GetFridgeModelAsync(Guid id, CancellationToken cancellationToken)
    {
        return await fridgesDbContext
            .FridgeModels
            .FirstOrDefaultAsync(model => model.Id == id, cancellationToken);
    }

    public async Task<FridgeModel> CreateFridgeModelsAsync(FridgeModel fridgeModel, CancellationToken cancellationToken)
    {
        await fridgesDbContext.FridgeModels.AddAsync(fridgeModel, cancellationToken);
        return fridgeModel;
    }

    public FridgeModel UpdateFridgeModel(FridgeModel fridgeModel)
    {
        return fridgesDbContext.FridgeModels.Update(fridgeModel).Entity;
    }

    public void DeleteFridgeModel(FridgeModel fridgeModel)
    {
        fridgesDbContext.FridgeModels.Remove(fridgeModel);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await fridgesDbContext.SaveChangesAsync(cancellationToken);
    }
}