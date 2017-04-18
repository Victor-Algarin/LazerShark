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
    public class UserAccessor
    {
        public static int VerifyUsernameAndPassword(string username, string passwordHash)
        {
            var result = 0;

            // Connecting to LazerSharkDB
            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_authenticate_user";

            // Creating commmand object
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Adding Parameters
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);

            // Setting parameter values
            cmd.Parameters["@Username"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                // Opening connection to LazerSharkDB
                conn.Open();

                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Closing the connection
                conn.Close();
            }
            return result;
        }

        public static int VerifyAdminLoginInfo(string username, string passwordHash)
        {
            var count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_authenticate_administrator";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);

            cmd.Parameters["@Username"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
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

        public static int ChangePasswordHash(string username, string oldPasswordHash, string newPasswordHash)
        {
            var count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_update_passwordHash";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.VarChar, 100);

            cmd.Parameters["@Username"].Value = username;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;

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

        public static int AddNewUser(string username, string passwordHash, string firstName, string lastName,  string phoneNumber, string address, string email)
        {
            int count = 0;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_add_user";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 250);
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 250);
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 9);
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 500);
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 200);

            cmd.Parameters["@Username"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;
            cmd.Parameters["@FirstName"].Value = firstName;
            cmd.Parameters["@LastName"].Value = lastName;
            cmd.Parameters["@PhoneNumber"].Value = phoneNumber;
            cmd.Parameters["@Address"].Value = address;
            cmd.Parameters["@Email"].Value = email;

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

        public static Customer RetrieveCustomerByUsername(string username)
        {
            Customer _customer = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_customer_by_username";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters["@Username"].Value = username;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    _customer = new Customer()
                    { // CustomerID, FirstName, LastName, PhoneNumber, Address, Email, Username
                        CustomerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Address = reader.GetString(4),
                        Email =reader.GetString(5),
                        Username = reader.GetString(6)
                    };
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
            return _customer;

        }

        public static Administrator RetrieveAdminByUsername(string username)
        {
            Administrator admin = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_administrator_by_username";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
            cmd.Parameters["@Username"].Value = username;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    admin = new Administrator()
                    { // AdministratorID, FirstName, LastName, Username
                        AdministratorID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Username = reader.GetString(3)
                    };
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
            return admin;
        }

    }
}
