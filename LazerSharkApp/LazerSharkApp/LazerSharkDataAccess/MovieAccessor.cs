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
            //cmd.Parameters.Add("@QuantityAvailable", SqlDbType.Int);
            //cmd.Parameters["@QuantityAvailable"].Value = quantityAvailable;

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
                            Medium = reader.GetString(5),
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

        public static List<Movie> RetrieveMoviesAccordingToGenre(string genreId)
        {
            var movies = new List<Movie>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_movies_by_medium";
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
                            Medium = reader.GetString(5),
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
    }
}
