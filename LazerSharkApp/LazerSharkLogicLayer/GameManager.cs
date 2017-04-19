using LazerSharkDataAccess;
using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class GameManager : LazerSharkLogicLayer.IGameManager
    {
        public List<Game> games = new List<Game>();
        
        public List<Game> RetrieveGamesForRental()
        {
            try
            {
                games = GameAccessor.RetrieveAllGames();
            }
            catch (Exception)
            {

            }
            return games;
        }

        public List<Game> RetrieveGamesByGenreID(string genreId)
        {
            try
            {
                games = GameAccessor.RetrieveGamesByGenre(genreId);
            }
            catch (Exception)
            {

                throw;
            }

            return games;
        }

        public List<Game> RetrieveGamesByMediumId(string mediumId)
        {
            try
            {
                games = GameAccessor.RetrieveGamesByMediumType(mediumId);
            }
            catch (Exception)
            {

                throw;
            }

            return games;
        }

        public List<Game> RetrieveGamesWithGenreAndMediumFilter(string genreId, string mediumId)
        {
            try
            {
                games = GameAccessor.RetrieveGamesByGenreAndMedium(genreId, mediumId);
            }
            catch (Exception)
            {

                throw;
            }

            return games;
        }

        public List<Game> RetrieveGamesInKiosk(int kioskId, int adminId)
        {
            try
            {
                games = GameAccessor.RetrieveGamesByKioskIdAndAdminId(kioskId, adminId);
            }
            catch (Exception)
            {

                throw;
            }

            return games;
        }

        public List<Game> RetrieveSupplierGamesStock(int supplierId)
        {
            try
            {
                games = GameAccessor.RetrieveGamesFromSupplier(supplierId);
            }
            catch (Exception)
            {

                throw;
            }

            return games;
        }

        public bool RemoveGamesFromKiosk(int gameId)
        {
            bool result = false;

            try
            {

                if (1 == GameAccessor.DeactivateGamesInKiosk(gameId, 1, 0))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {

            }

            return result;

        }

        public bool AddGamesToKiosk(int gameId)
        {
            bool result = false;

            try
            {
                if (1 == GameAccessor.ActivateGames(gameId, 0, 1))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {

                
            }

            return result;
        }


        public bool CreateGame(Game game)
        {
            try
            {
                return (GameAccessor.InsertGame(game) == 1);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
