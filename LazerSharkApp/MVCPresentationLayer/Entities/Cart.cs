using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPresentationLayer.Entities
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public void AddMovie(Movie movie, int quantity)
        {
            bool isPresent = false;
            foreach (var line in lines)
            {
                if (line.Movie != null)
                {
                    if (line.Movie.MovieID == movie.MovieID)
                    {
                        line.MovieQuantity += quantity;
                        isPresent = true;
                    }
                }

            }
            if (isPresent == false)
            {
                lines.Add(new CartLine { Movie = movie, MovieQuantity = quantity });
            }


        }

        public void AddGame(Game game, int quantity)
        {
            bool isPresent = false;
            foreach (var line in lines)
            {
                if (line.Game != null)
                {
                    if (line.Game.GameID == game.GameID)
                    {
                        line.GameQuantity += quantity;
                        isPresent = true;
                    }
                }
            }
            if (isPresent == false)
            {
                lines.Add(new CartLine { Game = game, GameQuantity = quantity });
            }
        }

        public void RemoveMovie(Movie movie)
        {
            if (lines.Count <= 1)
            {
                lines.RemoveAll(m => m.Movie.MovieID == movie.MovieID);
            }
            else
            {
                foreach (var line in lines)
                {
                    if (line.Movie != null)
                    {
                        lines.Remove(new CartLine { Movie = movie });
                    }
                }
            }


        }

        public void RemoveGame(Game game)
        {

            if (lines.Count <= 1)
            {
                lines.RemoveAll(g => g.Game.GameID == game.GameID);
            }
            else
            {
                foreach (var line in lines)
                {
                    if (line.Movie != null)
                    {
                        lines.Remove(new CartLine { Game = game });
                    }
                }
            }
        }

        public decimal CalculateTotalMoviePrice()
        {
            decimal price = 0;
            try
            {
                price = lines.Sum(m => m.Movie.RentalPrice * m.MovieQuantity);
            }
            catch (Exception)
            {
            }
            return price;
           
        }

        public decimal CalculateTotalGamePrice()
        {
            decimal price = 0;
            try
            {
                price = lines.Sum(m => m.Game.RentalPrice * m.GameQuantity);
            }
            catch (Exception)
            {
            }
            return price;
        }

        public decimal CalculateTotalValue()
        {
            decimal moviePrices = CalculateTotalMoviePrice();
            decimal gamePrices = CalculateTotalGamePrice();
            return (moviePrices + gamePrices);
        }

        public void Clear()
        {
            lines.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lines; }
        }

        public class CartLine
        {
            public Movie Movie { get; set; }
            public Game Game { get; set; }
            public int MovieQuantity { get; set; }
            public int GameQuantity { get; set; }
        }

    }
}
