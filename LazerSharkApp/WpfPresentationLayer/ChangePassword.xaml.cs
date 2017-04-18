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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        Customer _customer;

        public ChangePassword(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var oldPassword = txtOldPassword.Password;
            var newPassword = txtNewPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;


            if (newPassword == oldPassword)
            {
                MessageBox.Show("You must choose a new password.");
                txtNewPassword.Clear();
                txtOldPassword.Clear();
                txtNewPassword.Focus();
            }
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();
            }
            else
            {
                try
                {
                    UserManager usrMgr = new UserManager();
                    if (usrMgr.UpdatePassword(_customer.Username, oldPassword, newPassword) == true)
                    {
                        MessageBox.Show("Password successfully updated");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There was a problem updating the password");

                    }
                }
                catch (Exception)
                {


                }
            }

           
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var _login = new Login();
            this.Close();
            MessageBox.Show("Password change request cancelled.");
            _login.ShowDialog();

        }
    }
}
