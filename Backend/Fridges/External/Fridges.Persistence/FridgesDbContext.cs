using System.Reflection;
using Fridges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fridges.Persistence;

public class FridgesDbContext : DbContext
{
    public DbSet<FridgeModel> FridgeModels { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
    public DbSet<Fridge> Fridges { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<FridgeProduct> FridgeProducts { get; set; }

    public FridgesDbContext(DbContextOptions<FridgesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}