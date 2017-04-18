using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
namespace LazerSharkLogicLayer
{
    public interface IMovieManager
    {
        bool AddMoviesToKiosk(int movieId);
        List<LazerSharkDataObjects.Movie> GetSupplierMovieStock(int supplierId);
        bool RemoveMovieFromKiosk(int movieId);
        List<LazerSharkDataObjects.Movie> RetrieveMoviesByGenre(string genreId);
        List<LazerSharkDataObjects.Movie> RetrieveMoviesByKioskIdAndAdminId(int kioskId, int adminId);
        List<LazerSharkDataObjects.Movie> RetrieveMoviesByMedium(string mediumId);
        List<LazerSharkDataObjects.Movie> RetrieveMoviesForRent();
        List<LazerSharkDataObjects.Movie> RetrieveMoviesWithGenreAndMedium(string genreId, string mediumId);
        bool CreateNewMovie(Movie moive);
        bool EditMovie(Movie oldMovie, Movie newMovie);
    }
}
