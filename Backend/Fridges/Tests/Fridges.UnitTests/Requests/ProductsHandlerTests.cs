using FluentAssertions;
using Fridges.Application.Requests.Products.Commands.CreateProduct;
using Fridges.Application.Requests.Products.Commands.DeleteProduct;
using Fridges.Application.Requests.Products.Commands.UpdateProduct;
using Fridges.Application.Services;
using Fridges.Domain;
using Moq;

namespace Fridges.UnitTests.Requests;

public class ProductsHandlerTests
{
    private readonly Mock<IFridgeModelsRepository> _mockFridgeModelsRepository = new Mock<IFridgeModelsRepository>();
    private readonly Mock<IManufactureRepository> _mockManufactureRepository = new Mock<IManufactureRepository>();
    private readonly Mock<IFridgeProductRepository> _fridgeProductRepository = new Mock<IFridgeProductRepository>();
    private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
    private readonly Mock<IFridgeRepository> _fridgeRepository = new Mock<IFridgeRepository>();

    [Fact]
    public async Task CreateProductHandler_CreateProduct()
    {
        // Arrange
        var handler = new CreateProductHandler(_productRepository.Object);
        
        var request = FakeDataGenerator.GenerateCreateProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _productRepository.Verify(m => m.CreateProductAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteProductHandler_DeleteProduct_WhenProductFound()
    {
        // Arrange
        var handler = new DeleteProductHandler(_productRepository.Object);
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateProduct);
        
        var request = FakeDataGenerator.GenerateDeleteProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _productRepository.Verify(m => m.DeleteProduct(It.IsAny<Product>()), Times.Once);
    }
    
    [Fact]
    public async Task UpdateProductHandler_ShouldThrowException_WhenProductNotFound()
    {
        // Arrange
        var handler = new UpdateProductHandler(_productRepository.Object);
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Product?)null);
        
        var request = FakeDataGenerator.GenerateUpdateProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<Exception>();
        _productRepository.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Never);
    }
    
    [Fact]
    public async Task UpdateProductHandler_UpdateProduct_WhenProductFound()
    {
        // Arrange
        var handler = new UpdateProductHandler(_productRepository.Object);
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateProduct);
        
        var request = FakeDataGenerator.GenerateUpdateProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _productRepository.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task DeleteProductHandler_ShouldThrowException_WhenProductNotFound()
    {
        // Arrange
        var handler = new DeleteProductHandler(_productRepository.Object);
        _productRepository
            .Setup(m => m.GetProductAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Product?)null);
        
        var request = FakeDataGenerator.GenerateDeleteProductRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<Exception>();
        _productRepository.Verify(m => m.DeleteProduct(It.IsAny<Product>()), Times.Never);
    }
    
}