using LazerSharkDataObjects;
using System;
namespace LazerSharkLogicLayer
{
    public interface IGameManager
    {
        bool AddGamesToKiosk(int gameId);
        bool RemoveGamesFromKiosk(int gameId);
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveGamesByGenreID(string genreId);
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveGamesByMediumId(string mediumId);
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveGamesForRental();
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveGamesInKiosk(int kioskId, int adminId);
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveGamesWithGenreAndMediumFilter(string genreId, string mediumId);
        System.Collections.Generic.List<LazerSharkDataObjects.Game> RetrieveSupplierGamesStock(int supplierId);
        bool CreateGame(Game game);
    }
}
