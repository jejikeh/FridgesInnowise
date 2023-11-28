using Fridges.Domain;

namespace Fridges.Application.Common.Models;

public record ManufactureFridgeModelDto(
    Guid Id,
    string Name,
    DateOnly ManufactureDate,
    Guid ManufactureId)
{
    public static ManufactureFridgeModelDto FromManufactureModel(FridgeModel manufacture)
    {
        return new ManufactureFridgeModelDto(
            manufacture.Id,
            manufacture.Name,
            manufacture.ManufactureDate,
            manufacture.ManufactureId
        );
    }
}