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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        private Administrator admin = null;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var usrMgr = new UserManager();

            if(admin == null)
            {
                try
                {
                   admin = usrMgr.AuthenticateAdmin(username, password);
                    MessageBox.Show(admin.AdministratorID + " " + admin.Username + " has successfully logged in...");
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Something went wrong....");
                }
            }
            else
            {
                admin = null;
                txtUsername.Focus();
            }

        }
    }
}
