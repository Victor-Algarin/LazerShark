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

            return games;
        }
    }
}
