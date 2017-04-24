using LazerSharkDataAccess;
using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
    public class MovieManager : IMovieManager
    {
        public List<Movie> movies = new List<Movie>();
        public Movie movie;
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

        public List<Movie> RetrieveMoviesByGenre(string genreId)
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

        public List<Movie> RetrieveMoviesByMedium(string mediumId)
        {
            try
            {
                movies = MovieAccessor.RetrieveMoviesWithMediumID(mediumId);
            }
            catch (Exception)
            {

                throw;
            }

            return movies;
        }

        public List<Movie> RetrieveMoviesWithGenreAndMedium(string genreId, string mediumId)
        {
            try
            {
                movies = MovieAccessor.RetrieveMoviesByGenreAndMedium(genreId, mediumId);
            }
            catch (Exception)
            {

                throw;
            }
            return movies;
        }

        public List<Movie> RetrieveMoviesByKioskIdAndAdminId(int kioskId, int adminId)
        {
            try
            {
                movies = MovieAccessor.RetrieveMoviesByKioskIdAndAdminId(kioskId, adminId);
            }
            catch (Exception)
            {

                throw;
            }
            return movies;
        }

        public List<Movie> GetSupplierMovieStock(int supplierId)
        {
            try
            {
                movies = MovieAccessor.RetrieveMoviesFromSupplier(supplierId);
            }
            catch (Exception)
            {

                throw;
            }
            return movies;
        }

        public bool RemoveMovieFromKiosk(int movieId)
        {
            var result = false;

            try
            {
                if (1 == MovieAccessor.DeactivateMovie(movieId, 1, 0))
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

        public bool AddMoviesToKiosk(int movieId)
        {
            var result = false;

            try
            {
                if (1 == MovieAccessor.ActivateMovie(movieId, 0, 1))
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

                throw new ApplicationException("There was a problem adding movies to the kiosk");
            }

            return result;
        }


        public bool CreateNewMovie(Movie movie)
        {
            try
            {
                return(MovieAccessor.CreateMovie(movie) == 1);
            }
            catch (Exception)
            {
                return false;
                throw new ApplicationException("Something went wrong... Movie creation failed.");
                
            }
        }


        public bool EditMovie(Movie oldMovie, Movie newMovie)
        {
            try
            {
                return (MovieAccessor.UpdateMovie(oldMovie, newMovie) == 1);
            }
            catch (Exception)
            {
                return false;
                throw new ApplicationException("Something went wrong... Movie creation failed.");
            }
        }




        public Movie RetrieveMovieByID(Movie movie)
        {
            try
            {
                movie = MovieAccessor.GetMovieByID(movie);
            }
            catch (Exception)
            {

            }
            return movie;
        }
    }
}
