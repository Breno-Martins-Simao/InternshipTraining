using GameStore.Models.API;
using GameStore.Models.DataBase;
using GameStore.Repositories;

namespace GameStore.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Este método recupera todos os jogos da base de dados.
        /// </summary>
        /// <returns>Retorna uma coleção de jogos. Se não houver jogos, retorna uma coleção vazia.</returns>
        IEnumerable<Game>? GetAllGames();

        /// <summary>
        /// Este metodo recupera o jogo da base de dados recebendo como parametro o ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Caso este metodo não encontre um jogo retornará nulo, Caso encontre retornará o jogo</returns>
        Game? GetGameByID(Guid id);

        /// <summary>
        /// Este método adiciona um novo jogo à base de dados.
        /// </summary>
        /// <param name="game">Os dados do jogo a ser adicionado.</param>
        /// <returns>Retorna o jogo adicionado.</returns>
        Game AddGame(GameRequest game);

        /// <summary>
        /// Este método atualiza os dados de um jogo existente na base de dados.
        /// </summary>
        /// <param name="id">O ID do jogo a ser atualizado.</param>
        /// <param name="game">Os novos dados do jogo.</param>
        /// <returns>Se o jogo for encontrado e atualizado, retorna o jogo atualizado; caso contrário, retorna nulo.</returns>
        Game? UpdateGame(Guid id, GameRequest game);

        /// <summary>
        /// Este método exclui um jogo da base de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID do jogo a ser excluído.</param>
        /// <returns>Se o jogo for encontrado e excluído, retorna o jogo excluído; caso contrário, retorna nulo.</returns>
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
