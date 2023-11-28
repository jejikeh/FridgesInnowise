using Fridges.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fridges.Persistence.ModelConfiguration;

public class ManufactureConfiguration : IEntityTypeConfiguration<Manufacture>
{
    public void Configure(EntityTypeBuilder<Manufacture> builder)
    {
        builder
            .HasMany(manufacture => manufacture.FridgeModels)
            .WithOne(fridgeModel => fridgeModel.Manufacture);

        builder.HasKey(manufacture => manufacture.Id);
    }
}