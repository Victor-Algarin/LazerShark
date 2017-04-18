using LazerSharkDataAccess;
using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class GameManager
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
    }
}
