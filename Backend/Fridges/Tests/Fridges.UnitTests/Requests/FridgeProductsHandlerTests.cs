using FluentAssertions;
using Fridges.Application.Common.Exceptions;
using Fridges.Application.Requests.FridgeProducts.Commands.CreateFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Commands.DeleteFridgeProduct;
using Fridges.Application.Requests.FridgeProducts.Commands.UpdateFridgeProduct;
using Fridges.Application.Services;
using Fridges.Domain;
using Moq;

namespace Fridges.UnitTests.Requests;

public class FridgeProductsHandlerTests
{
    private readonly Mock<IFridgeModelsRepository> _mockFridgeModelsRepository = new Mock<IFridgeModelsRepository>();
    private readonly Mock<IManufactureRepository> _mockManufactureRepository = new Mock<IManufactureRepository>();
    private readonly Mock<IFridgeProductRepository> _fridgeProductRepository = new Mock<IFridgeProductRepository>();
    private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
    private readonly Mock<IFridgeRepository> _fridgeRepository = new Mock<IFridgeRepository>();
    
    [Fact]
    public async Task CreateFridgeProductsHandler_ShouldThrowNotFoundException_WhenFridgeModelNotFound()
    {
        // Arrange
        var handler = new CreateFridgeProductHandler(_fridgeProductRepository.Object, _fridgeRepository.Object, _productRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeModel?) null);
        
        var request = FakeDataGenerator.GenerateCreateFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task CreateFridgeProductsHandler_ShouldThrowNotFoundException_WhenProductNotFound()
    {
        // Arrange
        var handler = new CreateFridgeProductHandler(_fridgeProductRepository.Object, _fridgeRepository.Object, _productRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Product?) null);
        
        var request = FakeDataGenerator.GenerateCreateFridgeProductRequest();
        
        // Act
        
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }

    [Fact]
    public async Task CreateFridgeProductsHandler_CreateFridgeProduct_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new CreateFridgeProductHandler(_fridgeProductRepository.Object, _fridgeRepository.Object, _productRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateProduct);
        
        var request = FakeDataGenerator.GenerateCreateFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeProductRepository.Verify(m => m.CreateFridgeProductAsync(It.IsAny<FridgeProduct>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    
    [Fact]
    public async Task CreateFridgeProductsHandler_CreateFridgeProductWithDefaultQuantity_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new CreateFridgeProductHandler(_fridgeProductRepository.Object, _fridgeRepository.Object, _productRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);

        var product = FakeDataGenerator.GenerateProduct();
        
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);
        
        var request = FakeDataGenerator.GenerateCreateFridgeProductRequestWithoutQuantity();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeProductRepository.Verify(m => m.CreateFridgeProductAsync(It.Is<FridgeProduct>(f => f.Quantity == product.DefaultQuantity), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteFridgeProductsHandler_DeleteFridgeProduct_WhenFridgeProductFound()
    {
        // Arrange
        var handler = new DeleteFridgeProductHandler(_fridgeProductRepository.Object);
        _fridgeProductRepository
            .Setup(m => m.GetFridgeProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeProduct);
        
        var request = FakeDataGenerator.GenerateDeleteFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeProductRepository.Verify(m => m.DeleteFridgeProduct(It.IsAny<FridgeProduct>()), Times.Once);
    }
    
    [Fact]
    public async Task DeleteFridgeProductsHandler_ShouldThrowNotFoundException_WhenFridgeProductNotFound()
    {
        // Arrange
        var handler = new DeleteFridgeProductHandler(_fridgeProductRepository.Object);
        _fridgeProductRepository
            .Setup(m => m.GetFridgeProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeProduct?) null);
        
        var request = FakeDataGenerator.GenerateDeleteFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateFridgeProductsHandler_UpdateFridgeProduct_WhenFridgeProductFound()
    {
        // Arrange
        var handler = new UpdateFridgeProductHandler(_fridgeProductRepository.Object, _productRepository.Object, _fridgeRepository.Object);
        _fridgeProductRepository
            .Setup(m => m.GetFridgeProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeProduct);
        
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateProduct);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
    }
    
    [Fact]
    public async Task UpdateFridgeProductsHandler_ShouldThrowNotFoundException_WhenFridgeProductNotFound()
    {
        // Arrange
        var handler = new UpdateFridgeProductHandler(_fridgeProductRepository.Object, _productRepository.Object, _fridgeRepository.Object);
        _fridgeProductRepository
            .Setup(m => m.GetFridgeProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeProduct?) null);
        
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateProduct);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
}