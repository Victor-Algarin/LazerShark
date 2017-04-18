using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataAccess
{
    public class GameAccessor
    {
        public static List<Game> RetrieveAllGames()
        {
            var games = new List<Game>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_all_available_games";
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
                        games.Add(new Game()
                        {
                            GameID = reader.GetInt32(0),
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

            return games;
        }

        public static List<Game> RetrieveGamesByGenre(string genreId)
        {
            var games = new List<Game>();
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_filter_games_by_genre";
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
                        games.Add(new Game()
                        {
                            GameID = reader.GetInt32(0),
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

            return games;
        }

        public static List<Game> RetrieveGamesByMediumType(string mediumId)
        {
            var games = new List<Game>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_games_by_medium";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MediumID", SqlDbType.VarChar, 10);
            cmd.Parameters["@MediumID"].Value = mediumId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        games.Add(new Game()
                        {
                            GameID = reader.GetInt32(0),
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
            return games;
        }

        public static List<Game> RetrieveGamesByGenreAndMedium(string genreId, string mediumId)
        {
            List<Game> games = new List<Game>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_filter_games_by_genre_and_medium";
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
                        games.Add(new Game
                        {
                            GameID = reader.GetInt32(0),
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
            return games;
        }

        public static List<Game> RetrieveGamesByKioskIdAndAdminId(int kioskId, int adminId)
        {
            List<Game> games = new List<Game>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retreive_games_by_kioskId_and_adminId";
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
                        games.Add(new Game
                        {
                            GameID = reader.GetInt32(0),
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

            return games;
        }

        public static List<Game> RetrieveGamesFromSupplier(int supplierId)
        {
            List<Game> games = new List<Game>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retreive_supplier_game_stock";
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
                        games.Add(new Game
                        {
                            GameID = reader.GetInt32(0),
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

            return games;
        }

        public static int DeactivateGamesInKiosk(int gameId, int oldActive, int newActive)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_change_game_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GameID", SqlDbType.Int);
            cmd.Parameters.Add("@OldActive", SqlDbType.Bit);
            cmd.Parameters.Add("@NewActive", SqlDbType.Bit);

            cmd.Parameters["@GameID"].Value = gameId;
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

        public static int ActivateGames(int gameId, int oldActive, int newActive)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_change_game_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@GameID", SqlDbType.Int);
            cmd.Parameters.Add("@OldActive", SqlDbType.Bit);
            cmd.Parameters.Add("@NewActive", SqlDbType.Bit);
            cmd.Parameters["@GameID"].Value = gameId;
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
    }
}
