using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class CartManager
    {
        private List<CartLine> lines = new List<CartLine>();

        public void AddMovie(Movie movie, int quantity)
        {
            CartLine line = lines.Where(m => m.Movie.MovieID == movie.MovieID).FirstOrDefault();

            if (line == null)
            {
                lines.Add(new CartLine { Movie = movie, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void AddGame(Game game, int quantity)
        {
            CartLine line = lines.Where(g => g.Game.GameID == game.GameID).FirstOrDefault();

            if (line == null)
            {
                lines.Add(new CartLine { Game = game, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveMovie(Movie movie)
        {
            lines.RemoveAll(m => m.Movie.MovieID == movie.MovieID);
        }

        public void RemoveGame(Game game)
        {
            lines.RemoveAll(g => g.Game.GameID == game.GameID);
        }

        public decimal CalculateTotalMoviePrice()
        {
            return lines.Sum(m => m.Movie.RentalPrice * m.Quantity);
        }

        public decimal CalculateTotalGamePrice()
        {
            return lines.Sum(g => g.Game.RentalPrice * g.Quantity);
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
            public int Quantity { get; set; }
        }

    }
}
