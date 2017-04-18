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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Customer _customer = null;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var userMgr = new UserManager();
            

            if(_customer == null)
            {
                try
                {
                    _customer = userMgr.AuthenticateUser(username, password);
                    MessageBox.Show("Welcome " + _customer.Username);
                    this.Close();

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


        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var userMgr = new UserManager();

            if (_customer == null)
            {
                try
                {
                    _customer = userMgr.AuthenticateUserForPasswordChange(username, password);
                    MessageBox.Show("Welcome " + _customer.Username);
                    var passwordChange = new ChangePassword(_customer);
                    this.Close();
                    passwordChange.ShowDialog();
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

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var createAccount = new CreateAccount();
            this.Close();
            createAccount.ShowDialog();
        }
    }
}
