using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataAccess
{
    public class MovieAccessor
    {
        public static List<Movie> RetrieveAvailableMovies()
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_available_movies";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie()
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8),
                            Active = true
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return movies;
        }

        public static List<Movie> RetrieveMoviesAccordingToGenre(string genreId)
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_filter_movies_by_genre";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GenreID", SqlDbType.VarChar, 50);
            cmd.Parameters["@GenreID"].Value = genreId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8),
                            Active = true
                        });
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return movies;
        }

        public static List<Movie> RetrieveMoviesWithMediumID(string mediumId)
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_movies_by_medium";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MediumID", SqlDbType.VarChar, 20);
            cmd.Parameters["@MediumID"].Value = mediumId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8),
                            Active = true
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return movies;
        }

        public static List<Movie> RetrieveMoviesByGenreAndMedium(string genreId, string mediumId)
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_filter_movies_by_genre_and_medium";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GenreID", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@MediumID", SqlDbType.VarChar, 20);
            cmd.Parameters["@GenreID"].Value = genreId;
            cmd.Parameters["@MediumID"].Value = mediumId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8),
                            Active = true
                        });
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return movies;

        }

        public static List<Movie> RetrieveMoviesByKioskIdAndAdminId(int kioskId, int adminId)
        {
            List<Movie> movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_movies_by_kioskId_and_adminId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@KioskID", SqlDbType.Int);
            cmd.Parameters.Add("@AdministratorID", SqlDbType.Int);
            cmd.Parameters["@KioskID"].Value = kioskId;
            cmd.Parameters["@AdministratorID"].Value = adminId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8),
                            Active = true
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return movies;
        }

        public static List<Movie> RetrieveMoviesFromSupplier(int supplierId)
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retreive_supplier_movie_stock";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SupplierID", SqlDbType.Int);
            cmd.Parameters["@SupplierID"].Value = supplierId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            MovieID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreID = reader.GetString(2),
                            Description = reader.GetString(3),
                            Rating = reader.GetString(4),
                            MediumID = reader.GetString(5),
                            QuantityAvailable = reader.GetInt32(6),
                            Quantity = reader.GetInt32(7),
                            RentalPrice = reader.GetDecimal(8)
                        });
                    }
                    reader.Close();
                }
            
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return movies;
        }

        public static int DeactivateMovie(int movieId, int oldActive, int newActive)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_change_movie_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MovieID", SqlDbType.Int);
            cmd.Parameters.Add("@OldActive", SqlDbType.Bit);
            cmd.Parameters.Add("@NewActive", SqlDbType.Bit);

            cmd.Parameters["@MovieID"].Value = movieId;
            cmd.Parameters["@OldActive"].Value = oldActive;
            cmd.Parameters["@NewActive"].Value = newActive;

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int ActivateMovie(int movieId, int oldActive, int newActive)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_change_movie_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MovieID", SqlDbType.Int);
            cmd.Parameters.Add("@OldActive", SqlDbType.Bit);
            cmd.Parameters.Add("@NewActive", SqlDbType.Bit);

            cmd.Parameters["@MovieID"].Value = movieId;
            cmd.Parameters["@OldActive"].Value = oldActive;
            cmd.Parameters["@NewActive"].Value = newActive;

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static int UpdateMovie(Movie oldMovie, Movie newMovie) 
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_edit_movie";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MovieID", oldMovie.MovieID);

            cmd.Parameters.AddWithValue("@OldDescription", oldMovie.Description);
            cmd.Parameters.AddWithValue("@OldQuantity", oldMovie.Quantity);
            cmd.Parameters.AddWithValue("@OldQuantityAvailable", oldMovie.QuantityAvailable);
            cmd.Parameters.AddWithValue("@OldRentalPrice", oldMovie.RentalPrice);
            cmd.Parameters.AddWithValue("@OldActive", oldMovie.Active);

            cmd.Parameters.AddWithValue("@NewDescription", newMovie.Description);
            cmd.Parameters.AddWithValue("@NewQuantity", newMovie.Quantity);
            cmd.Parameters.AddWithValue("@NewQuantityAvailable", newMovie.QuantityAvailable);
            cmd.Parameters.AddWithValue("@NewRentalPrice", newMovie.RentalPrice);
            cmd.Parameters.AddWithValue("@NewActive", newMovie.Active);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public static int CreateMovie(Movie movie)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_create_movie";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@GenreID", movie.GenreID);
            cmd.Parameters.AddWithValue("@Description", movie.Description);
            cmd.Parameters.AddWithValue("@Rating", movie.Rating);
            cmd.Parameters.AddWithValue("@MediumID", movie.MediumID);
            cmd.Parameters.AddWithValue("@QuantityAvailable", movie.QuantityAvailable);
            cmd.Parameters.AddWithValue("@Quantity", movie.Quantity);
            cmd.Parameters.AddWithValue("@RentalPrice", movie.RentalPrice);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        public static Movie GetMovieByID(Movie movieParam)
        {
            Movie movie = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_movie_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MovieID", movieParam.MovieID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie.MovieID = reader.GetInt32(0);
                        movie.Title = reader.GetString(1);
                        movie.GenreID = reader.GetString(2);
                        movie.Description = reader.GetString(3);
                        movie.Rating = reader.GetString(4);
                        movie.MediumID = reader.GetString(5);
                        movie.QuantityAvailable = reader.GetInt32(6);
                        movie.Quantity = reader.GetInt32(7);
                        movie.RentalPrice = reader.GetDecimal(8);
                        movie.Active = reader.GetBoolean(9);
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                conn.Close();
            }

            return movie;
        }
    }
}
