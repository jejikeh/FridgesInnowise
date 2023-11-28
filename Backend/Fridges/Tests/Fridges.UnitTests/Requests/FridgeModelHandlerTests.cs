using FluentAssertions;
using Fridges.Application.Common.Exceptions;
using Fridges.Application.Requests.FridgeModels.Commands.CreateFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.DeleteFridgeModel;
using Fridges.Application.Requests.FridgeModels.Commands.UpdateFridgeModel;
using Fridges.Application.Services;
using Fridges.Domain;
using Moq;

namespace Fridges.UnitTests.Requests;

public class FridgeModelHandlerTests
{
    private readonly Mock<IFridgeModelsRepository> _mockFridgeModelsRepository = new Mock<IFridgeModelsRepository>();
    private readonly Mock<IManufactureRepository> _mockManufactureRepository = new Mock<IManufactureRepository>();

    [Fact]
    public async Task CreateFridgeModelHandler_ShouldThrowNotFoundException_WhenManufactureNotFound()
    {
        // Arrange
        var handler = new CreateFridgeModelHandler(_mockFridgeModelsRepository.Object, _mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Manufacture?) null);

        var request = FakeDataGenerator.GenerateCreateFridgeModelRequest();

        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task CreateFridgeModelHandler_CreateFridgeModel_WhenManufactureFound()
    {
        // Arrange
        var handler = new CreateFridgeModelHandler(_mockFridgeModelsRepository.Object, _mockManufactureRepository.Object);
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateManufacture);

        _mockFridgeModelsRepository
            .Setup(m => m.CreateFridgeModelsAsync(It.IsAny<FridgeModel>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel());

        var request = FakeDataGenerator.GenerateCreateFridgeModelRequest();

        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _mockFridgeModelsRepository.Verify(m => m.CreateFridgeModelsAsync(It.IsAny<FridgeModel>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteFridgeModelHandler_ShouldThrowNotFoundException_WhenFridgeModelNotFound()
    {
        // Arrange
        var handler = new DeleteFridgeModelHandler(_mockFridgeModelsRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeModel?)null);

        var request = FakeDataGenerator.GenerateDeleteFridgeModelRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }

    [Fact]
    public async Task DeleteFridgeModelHandler_DeleteFridgeModel_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new DeleteFridgeModelHandler(_mockFridgeModelsRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);

        var request = FakeDataGenerator.GenerateDeleteFridgeModelRequest();

        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _mockFridgeModelsRepository.Verify(m => m.DeleteFridgeModel(It.IsAny<FridgeModel>()), Times.Once);
    }

    [Fact]
    public async Task UpdateFridgeModelHandler_ShouldThrowNotFoundException_WhenFridgeModelNotFound()
    {
        // Arrange
        var handler = new UpdateFridgeModelHandler(_mockFridgeModelsRepository.Object, _mockManufactureRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FridgeModel?)null);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeModelRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateFridgeModelHandler_ShouldThrowNotFoundException_WhenManufactureNotFound()
    {
        // Arrange
        var handler = new UpdateFridgeModelHandler(_mockFridgeModelsRepository.Object, _mockManufactureRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Manufacture?)null);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeModelRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<HttpNotFoundException>();
    }
    
    [Fact]
    public async Task UpdateFridgeModelHandler_UpdateFridgeModel_WhenFridgeModelFound()
    {
        // Arrange
        var handler = new UpdateFridgeModelHandler(_mockFridgeModelsRepository.Object, _mockManufactureRepository.Object);
        _mockFridgeModelsRepository
            .Setup(m => m.GetFridgeModelAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateFridgeModel);
        
        _mockManufactureRepository
            .Setup(m => m.GetManufactureAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(FakeDataGenerator.GenerateManufacture);
        
        var request = FakeDataGenerator.GenerateUpdateFridgeModelRequest();
        
        // Act
        var act = async () => await handler.Handle(request, CancellationToken.None);
        
        // Assert
        await act.Should().NotThrowAsync();
        _mockFridgeModelsRepository.Verify(m => m.UpdateFridgeModel(It.IsAny<FridgeModel>()), Times.Once);
    }
}