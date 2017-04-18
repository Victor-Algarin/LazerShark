using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class MediaManager
    {
        public List<Game> games = new List<Game>();
        public List<Movie> movies = new List<Movie>();
        decimal moviePrices;
        decimal gamePrices;
        decimal total = 0;



        public decimal CalculateMoviesTotal(decimal moviePrices)
        {
            decimal movieTotal = 0;
            this.moviePrices += moviePrices;
            movieTotal = moviePrices;
            total += moviePrices;

            return movieTotal;
        }

        public void DeductMoviePrice(decimal moviePrice)
        {
            total -= moviePrice;
        }

        public void deductGamePrice(decimal gamePrice)
        {
            total -= gamePrice;
        }

        public decimal CalculateGamesTotal(decimal gamePrices)
        {
            decimal gameTotal = 0;
            this.gamePrices += gamePrices;
            gameTotal = gamePrices;
            total += gamePrices;
            return gameTotal;
        }

        public void clearTotal()
        {
            gamePrices = 0;
            moviePrices = 0;
        }

        public decimal sumPrices()
        {
            return gamePrices + moviePrices;
        }
    }
}
