using Bogus;
using Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;
using Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;
using Fridges.Application.Requests.Fridges.Commands.CreateFridge;
using Fridges.Application.Requests.Fridges.Commands.DeleteFridge;
using Fridges.Application.Requests.Fridges.Commands.UpdateFridge;
using Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;
using Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;
using Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;
using Fridges.Application.Requests.Products.Commands.CreateProduct;
using Fridges.Application.Requests.Products.Commands.DeleteProduct;
using Fridges.Application.Requests.Products.Commands.UpdateProduct;
using Fridges.Domain;

namespace Fridges.UnitTests;

public static class FakeDataGenerator
{
    public static CreateFridgeModelRequest GenerateCreateFridgeModelRequest()
    {
        return new Faker<CreateFridgeModelRequest>()
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.ManufactureId,  Guid.NewGuid())
            .RuleFor(x => x.ManufactureDate,  faker => faker.Date.PastDateOnly());
    }
    
    public static FridgeModel GenerateFridgeModel()
    {
        return new Faker<FridgeModel>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.ManufactureId,  Guid.NewGuid())
            .RuleFor(x => x.ManufactureDate,  faker => faker.Date.PastDateOnly());
    }

    public static Manufacture GenerateManufacture()
    {
        return new Faker<Manufacture>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName());
    }

    public static DeleteFridgeRequest GenerateDeleteFridgeRequest()
    {
        return new DeleteFridgeRequest(Guid.NewGuid());
    }
    
    public static DeleteFridgeModelRequest GenerateDeleteFridgeModelRequest()
    {
        return new DeleteFridgeModelRequest(Guid.NewGuid());
    }

    public static UpdateFridgeModelRequest GenerateUpdateFridgeModelRequest()
    {
        return new Faker<UpdateFridgeModelRequest>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.ManufactureId,  Guid.NewGuid())
            .RuleFor(x => x.ManufactureDate,  faker => faker.Date.PastDateOnly());
    }

    public static CreateFridgeProductRequest GenerateCreateFridgeProductRequestWithoutQuantity()
    {
        return new Faker<CreateFridgeProductRequest>()
            .RuleFor(x => x.ProductId, Guid.NewGuid())
            .RuleFor(x => x.FridgeId, Guid.NewGuid())
            .RuleFor(x => x.Quantity, 0);
    }
    
    public static CreateFridgeProductRequest GenerateCreateFridgeProductRequest()
    {
        return new Faker<CreateFridgeProductRequest>()
            .RuleFor(x => x.ProductId, Guid.NewGuid())
            .RuleFor(x => x.FridgeId, Guid.NewGuid())
            .RuleFor(x => x.Quantity, Random.Shared.Next(1, 100));
    }

    public static Product GenerateProduct()
    {
        return new Faker<Product>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.DefaultQuantity, Random.Shared.Next(1, 100));
    }

    public static Fridge GenerateFridge()
    {
        return new Faker<Fridge>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.OwnerName, faker => faker.Person.FullName)
            .RuleFor(x => x.ModelId,  Guid.NewGuid());
    }

    public static FridgeProduct GenerateFridgeProduct()
    {
        return new Faker<FridgeProduct>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.ProductId, Guid.NewGuid())
            .RuleFor(x => x.FridgeId, Guid.NewGuid())
            .RuleFor(x => x.Quantity, 0);
    }

    public static DeleteFridgeProductRequest GenerateDeleteFridgeProductRequest()
    {
        return new DeleteFridgeProductRequest(Guid.NewGuid());
    }
    
    public static UpdateFridgeProductRequest GenerateUpdateFridgeProductRequest()
    {
        return new Faker<UpdateFridgeProductRequest>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.ProductId, Guid.NewGuid())
            .RuleFor(x => x.FridgeId, Guid.NewGuid())
            .RuleFor(x => x.Quantity, Random.Shared.Next(1, 100));
    }

    public static CreateFridgeRequest GenerateCreateFridgeRequest()
    {
        return new Faker<CreateFridgeRequest>()
            .RuleFor(x => x.OwnerName, faker => faker.Person.FullName)
            .RuleFor(x => x.ModelId,  Guid.NewGuid());
    }

    public static UpdateFridgeRequest GenerateUpdateFridgeRequest()
    {
        return new Faker<UpdateFridgeRequest>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.OwnerName, faker => faker.Person.FullName)
            .RuleFor(x => x.ModelId,  Guid.NewGuid());
    }

    public static CreateManufactureRequest GenerateCreateManufactureRequest()
    {
        return new Faker<CreateManufactureRequest>()
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName());
    }

    public static DeleteManufactureRequest GenerateDeleteManufactureRequest()
    {
        return new DeleteManufactureRequest(Guid.NewGuid());
    }

    public static UpdateManufactureRequest GenerateUpdateManufactureRequest()
    {
        return new Faker<UpdateManufactureRequest>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName());
    }

    public static CreateProductRequest GenerateCreateProductRequest()
    {
        return new Faker<CreateProductRequest>()
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.DefaultQuantity, Random.Shared.Next(1, 100));
    }

    public static DeleteProductRequest GenerateDeleteProductRequest()
    {
        return new DeleteProductRequest(Guid.NewGuid());
    }

    public static UpdateProductRequest GenerateUpdateProductRequest()
    {
        return new Faker<UpdateProductRequest>()
            .RuleFor(x => x.Id, Guid.NewGuid())
            .RuleFor(x => x.Name, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.DefaultQuantity, Random.Shared.Next(1, 100));
    }
}