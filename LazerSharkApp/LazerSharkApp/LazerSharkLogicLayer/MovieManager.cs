using LazerSharkDataAccess;
using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class MovieManager
    {
        public List<Movie> movies = new List<Movie>();

        public List<Movie> RetrieveMoviesForRent()
        {
            try
            {
                movies = MovieAccessor.RetrieveAvailableMovies();
            }
            catch (Exception)
            {

                
            }
            return movies;           
        }

        public List<Movie>RetrieveMoviesByGenre(string genreId)
        {
            try
            {
                movies = MovieAccessor.RetrieveMoviesAccordingToGenre(genreId);
            }
            catch (Exception)
            {
                throw;
            }
            return movies;
        }
    }
}
