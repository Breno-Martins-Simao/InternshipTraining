using GameStore.Models.API;
using GameStore.Models.DataBase;
using GameStore.Repositories;

namespace GameStore.Interfaces
{
    public interface IGameService
    {
        IEnumerable<Game>? GetAllGames();

        /// <summary>
        /// Este metodo recupera o jogo da base de dados recebendo como parametro o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Caso este metodo não encontre um jogo retornará nulo, Caso encontre retornará o jogo</returns>
        Game? GetGameByID(Guid id);
        Game AddGame(GameRequest game);
        Game? UpdateGame(Guid id, GameRequest game);
        Game? DeleteGame(Guid id);
    }

    public interface IGameRepository
    {
        IEnumerable<Game>? GetAllGames();
        Game? GetGameByID(Guid id);
        Game AddGame(GameRequest game);
        Game? UpdateGame(Guid id, GameRequest game);
        Game? DeleteGame(Guid id);
    }
}
