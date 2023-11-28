using System.Text.Json.Serialization;

namespace Fridges.Domain;

public class FridgeModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly ManufactureDate { get; set; }
    [JsonIgnore] public Guid ManufactureId { get; set; }
    public Manufacture Manufacture { get; set; } = null!;
}