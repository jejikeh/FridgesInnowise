using FluentAssertions;
using Fridges.Application.Common.Exceptions;
using Fridges.Application.Requests.Manufactures.Commands.CreateManufacture;
using Fridges.Application.Requests.Manufactures.Commands.DeleteManufacture;
using Fridges.Application.Requests.Manufactures.Commands.UpdateManufacture;
using Fridges.Application.Services;
using Fridges.Domain;
using Moq;

namespace Fridges.UnitTests.Requests;

public class ManufacturesHandlerTests
{
    private readonly Mock<IFridgeModelsRepository> _mockFridgeModelsRepository = new Mock<IFridgeModelsRepository>();
    private readonly Mock<IManufactureRepository> _mockManufactureRepository = new Mock<IManufactureRepository>();
    private readonly Mock<IFridgeProductRepository> _fridgeProductRepository = new Mock<IFridgeProductRepository>();
    private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
    private readonly Mock<IFridgeRepository> _fridgeRepository = new Mock<IFridgeRepository>();

    [Fact]
    public async Task CreateManufacturesHandler_CreateManufacture_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new CreateManufactureHandler(_mockManufactureRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        var request = FakeDataGenerator.GenerateCreateManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
    }
    
    [Fact]
    public async Task DeleteManufactureHandler_DeleteManufacture_WhenManufactureFound()
    {
        // Arrange
        var handler = new DeleteManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateManufacture);
            
        var request = FakeDataGenerator.GenerateDeleteManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
    }
    
    [Fact]
    public async Task DeleteManufactureHandler_ShouldThrowNotFoundException_WhenManufactureNotFound()
    {
        // Arrange
        var handler = new DeleteManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Manufacture?) null);
        
        var request = FakeDataGenerator.GenerateDeleteManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateManufactureHandler_UpdateManufacture_WhenManufactureFound()
    {
        // Arrange
        var handler = new UpdateManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateManufacture);
        
        var request = FakeDataGenerator.GenerateUpdateManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _mockManufactureRepository.Verify(m => m.UpdateManufacture(It.IsAny<Manufacture>()), Times.Once);
    }
    
    [Fact]
    public async Task UpdateManufactureHandler_ShouldThrowNotFoundException_WhenManufactureNotFound()
    {
        // Arrange
        var handler = new UpdateManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Manufacture?) null);
        
        var request = FakeDataGenerator.GenerateUpdateManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task DeleteManufactureHandler_ShouldThrowNotFoundException_WhenFridgeNotFound()
    {
        // Arrange
        var handler = new DeleteManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Manufacture?) null);
        
        var request = FakeDataGenerator.GenerateDeleteManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task DeleteManufactureHandler_DeleteManufacture_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new DeleteManufactureHandler(_mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateManufacture);
        
        var request = FakeDataGenerator.GenerateDeleteManufactureRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _mockManufactureRepository.Verify(m => m.DeleteManufacture(It.IsAny<Manufacture>()), Times.Once);
    }
}