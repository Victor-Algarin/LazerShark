using LazerSharkDataAccess;
using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkLogicLayer
{
   public class UserManager
    {
        internal string HashSHA256(string source)
        {
            var result = "";

            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var s = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();
            return result;
        }

        public Customer AuthenticateUser(string username, string password)
        {
            Customer _customer = null;
            

            if (username.Length == 0)
            {
                throw new ApplicationException("You must enter a username to log in");
            }
            else if (username.Length < 5 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username....");
            }
             
            if (password.Length < 7)
            {
                throw new ApplicationException("Invalid Password");
            }

            try
            {
                if (1 == UserAccessor.VerifyUsernameAndPassword(username, HashSHA256(password)))
                {
                    password = null;
                    _customer = UserAccessor.RetrieveCustomerByUsername(username);
                    
                }
                else
                {
                    throw new ApplicationException("The username or password that you entered does not match our records!");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _customer;
        }

        public Administrator AuthenticateAdmin(string username, string password)
        {
            Administrator admin = null;

            if (username.Length == 0)
            {
                throw new ApplicationException("You must enter a username to log in");
            }
            else if (username.Length < 5 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username");
            }

            if (password.Length < 7)
            {
                throw new ApplicationException("Invalid Password");
            }
            try
            {
                if(1 == UserAccessor.VerifyAdminLoginInfo(username, HashSHA256(password))){
                    password = null;

                    admin = UserAccessor.RetrieveAdminByUsername(username);
                }
                else
                {
                    throw new ApplicationException("You have entered the wrong username or password");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return admin;
        }

        public Customer AuthenticateUserForPasswordChange(string username, string password)
        {
            Customer _customer = null;

            if (username.Length == 0)
            {
                throw new ApplicationException("You must enter your username and current password to change your password");
            }
            else if (username.Length < 5 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username");
            }

            if (password.Length < 7)
            {
                throw new ApplicationException("Invalid Password");
            }

            try
            {
                if (1 == UserAccessor.VerifyUsernameAndPassword(username, HashSHA256(password)))
                {
                    password = null;

                    _customer = UserAccessor.RetrieveCustomerByUsername(username);
                }
                else
                {
                    throw new ApplicationException("The username or password that you entered does not match our records!");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return _customer;
        }

        public bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            var result = false;

            try
            {       
                      
                if(1 == UserAccessor.ChangePasswordHash(username, HashSHA256(oldPassword), HashSHA256(newPassword)))
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

                throw new ApplicationException("There was an issue when attempting to remove movie...");
            }
            return result;
        }

        public bool CreateAccount(string username, string password, string firstName, string lastName, string phoneNumber, string address, string email)
        {
            var result = false;

            if(username.Length < 5 || username.Length > 20)
            {
                throw new ApplicationException("INVALID USERNAME: Your username must be at least 6 characters and no more than 20 characters long.");
            } 
            else if (password.Length < 7)
            {
                throw new ApplicationException("INVALID PASSWORD: Your Password must be at least 7 characters long.");
            }

            try
            {
                if (1 == UserAccessor.AddNewUser(username, HashSHA256(password), firstName, lastName, phoneNumber, address, email))
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

                throw;
            }

            return result;
        }
    }
}
