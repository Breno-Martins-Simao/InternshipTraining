using GameStore.Data;
using GameStore.Models.API;
using GameStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests;
public class GameRepositoryTests
{
    private readonly GameDbContext _context;
    private readonly GameRepository _repository;

    public GameRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<GameDbContext>()
            .UseInMemoryDatabase(databaseName: "GameStoreTestDb")
            .Options;

        _context = new GameDbContext(options);
        _repository = new GameRepository(_context);
    }

    [Fact]
    public async Task AddGame_AddGameToDatabase()
    {
        // Arrange
        var newGame = new GameRequest { Title = "New Game", Genre = "Action", Platform = "Console" };

        // Act
        await _repository.AddGame(newGame);

        // Assert
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Title == "New Game");
        Assert.NotNull(game);
        Assert.Equal("Action", game.Genre);
        Assert.Equal("Console", game.Platform);
    }
}
