using LazerSharkDataObjects;
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
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : Window
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank You! Your rental has been reserved...");
            Application.Current.Shutdown();            
        }

        public void populateMoviesToConfirmationList(List<Movie> selections)
        {
            foreach (var movie in selections)
            {
                 lstConfirmation.Items.Add(movie.Title);
            }
        }

        public void populateGamesToConfirmationList(List<Game> gameSelection)
        {
            foreach (var game in gameSelection)
            {
                lstConfirmation.Items.Add(game.Title);
            }
            
        }

        public void displayTotal(decimal total)
        {
            txtTotal.Text = "$" + total.ToString();
        }
    }
}
