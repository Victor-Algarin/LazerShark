using LazerSharkDataObjects;
using LazerSharkLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private Customer _customer = null;

        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var phoneNumber = txtPhoneNumber.Text;
            var address = txtAddress.Text;
            var email = txtEmail.Text;

            if(password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match...");
                txtConfirmPassword.Clear();
                txtPassword.Focus();
            }

            try
            {
                UserManager usrMgr = new UserManager();
                if(usrMgr.CreateAccount(username, password, firstName, lastName, phoneNumber, address, email) == true)
                {
                    MessageBox.Show("New account successfully Created!");
                    this.Close();

                    if (_customer == null)
                    {
                        try
                        {
                            _customer = usrMgr.AuthenticateUser(username, password);
                            MessageBox.Show("Welcome " + _customer.Username);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Authentication Failed...");
                        }
                    }
                    else
                    {
                        _customer = null;
                        txtUsername.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("There was a problem creating your account.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
