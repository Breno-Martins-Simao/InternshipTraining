using GameStore.Controllers;
using GameStore.Interfaces;
using GameStore.Models.API;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests;
public class GamesControllerTests
{
    // Mock para o serviço IGameService
    private readonly Mock<IGameService> _mockGameService;

    // Construtor para inicializar o mock
    public GamesControllerTests()
    {
        _mockGameService = new Mock<IGameService>();
    }

    [Fact]
    public async Task PostGame_ValidGame_ReturnsCreatedAtAction()
    {
        // Arrange
        var newGame = new GameRequest { Id = 1, Title = "New Game", Genre = "Action", Platform = "Console"};
        _mockGameService.Setup(service => service.AddGame(newGame)).Returns(Task.CompletedTask);
        var controller = new GamesController(_mockGameService.Object);

        // Act
        var result = await controller.PostGame(newGame);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(nameof(GamesController.GetGame), createdAtActionResult.ActionName);
        Assert.Equal(newGame, createdAtActionResult.Value);
    }

    [Fact]
    public async Task PostGame_InvalidGame_ReturnsBadRequest()
    {
        // Arrange
        var invalidGame = new GameRequest { Id = 0 }; // ID inválido
        _mockGameService.Setup(service => service.AddGame(invalidGame))
            .ThrowsAsync(new ArgumentException("Invalid game data"));
        var controller = new GamesController(_mockGameService.Object);

        // Act
        var result = await controller.PostGame(invalidGame);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Invalid game data", badRequestResult.Value);
    }
}
