using FluentAssertions;
using Fridges.Application.Common.Exceptions;
using Fridges.Application.Requests.Fridges.Commands.CreateFridge;
using Fridges.Application.Requests.Fridges.Commands.DeleteFridge;
using Fridges.Application.Requests.Fridges.Commands.UpdateFridge;
using Fridges.Application.Services;
using Fridges.Domain;
using Moq;

namespace Fridges.UnitTests.Requests;

public class FridgesHandlerTests
{
    private readonly Mock<IFridgeModelsRepository> _mockFridgeModelsRepository = new Mock<IFridgeModelsRepository>();
    private readonly Mock<IManufactureRepository> _mockManufactureRepository = new Mock<IManufactureRepository>();
    private readonly Mock<IFridgeProductRepository> _fridgeProductRepository = new Mock<IFridgeProductRepository>();
    private readonly Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
    private readonly Mock<IFridgeRepository> _fridgeRepository = new Mock<IFridgeRepository>();
    
    [Fact]
    public async Task CreateFridgeHandler_ShouldThrowNotFoundException_WhenFridgeModelNotFound()
    {
        // Arrange
        var handler = new CreateFridgeHandler(_mockFridgeModelsRepository.Object, _fridgeRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeModel?) null);
        
        var request = FakeDataGenerator.GenerateCreateFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }

    [Fact]
    public async Task CreateFridgeHandler_CreateFridge_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new CreateFridgeHandler(_mockFridgeModelsRepository.Object, _fridgeRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        _fridgeRepository
            .Setup(m => m.CreateFridgeAsync(It.IsAny<Fridge>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        var request = FakeDataGenerator.GenerateCreateFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeRepository.Verify(m => m.CreateFridgeAsync(It.IsAny<Fridge>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateFridgeHandler_ShouldThrowNotFoundException_WhenFridgeNotFound()
    {
        // Arrange
        var handler = new UpdateFridgeHandler(_fridgeRepository.Object, _mockFridgeModelsRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Fridge?) null);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateFridgeHandler_ShouldThrowNotFoundException_WhenFridgeModelNotFound()
    {
        // Arrange
        var handler = new UpdateFridgeHandler(_fridgeRepository.Object, _mockFridgeModelsRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeModel?) null);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateFridgeHandler_UpdateFridge_WhenFridgeAndFridgeModelFound()
    {
        // Arrange
        var handler = new UpdateFridgeHandler(_fridgeRepository.Object, _mockFridgeModelsRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeRepository.Verify(m => m.UpdateFridge(It.IsAny<Fridge>()), Times.Once);
    }
    
    [Fact]
    public async Task DeleteFridgeHandler_ShouldThrowNotFoundException_WhenFridgeNotFound()
    {
        // Arrange
        var handler = new DeleteFridgeHandler(_fridgeRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Fridge?) null);
        
        var request = FakeDataGenerator.GenerateDeleteFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task DeleteFridgeHandler_DeleteFridge_WhenFridgeFound()
    {
        // Arrange
        var handler = new DeleteFridgeHandler(_fridgeRepository.Object);
        _fridgeRepository
            .Setup(m => m.GetFridgeAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridge);
        
        var request = FakeDataGenerator.GenerateDeleteFridgeRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _fridgeRepository.Verify(m => m.DeleteFridge(It.IsAny<Fridge>()), Times.Once);
    }
}