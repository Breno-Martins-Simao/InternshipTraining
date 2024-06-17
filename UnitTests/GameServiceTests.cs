using GameStore.Interfaces;
using GameStore.Models.API;
using GameStore.Services;
using Moq;

namespace UnitTests;
public class GamesServiceTests
{
    private readonly Mock<IGameRepository> _gameRepositoryMock;
    private readonly GamesService _gamesService;

    public GamesServiceTests()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _gamesService = new GamesService(_gameRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllGames_ReturnAllGames()
    {
        // Arrange
        var games = new List<GameRequest> { new GameRequest(), new GameRequest() };
        _gameRepositoryMock.Setup(repo => repo.GetAllGames()).ReturnsAsync(games);

        // Act
        var result = await _gamesService.GetAllGames();

        // Assert
        Assert.Equal(games, result);
    }

    [Fact]
    public async Task GetGamesByID_ExistingId_ReturnGame()
    {
        // Arrange
        var gameId = 1;
        var game = new GameRequest { Id = gameId };
        _gameRepositoryMock.Setup(repo => repo.GetGamesByID(gameId)).ReturnsAsync(game);

        // Act
        var result = await _gamesService.GetGamesByID(gameId);

        // Assert
        Assert.Equal(game, result);
    }

    [Fact]
    public async Task GetGamesByID_NonExistingId_ReturnNull()
    {
        // Arrange
        var gameId = 1;
        _gameRepositoryMock.Setup(repo => repo.GetGamesByID(gameId)).ReturnsAsync((GameRequest)null);

        // Act
        var result = await _gamesService.GetGamesByID(gameId);

        // Assert
        Assert.Null(result);
    }
}