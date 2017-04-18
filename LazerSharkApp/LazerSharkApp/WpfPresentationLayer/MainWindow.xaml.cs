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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager usrMgr = new UserManager();
        private MovieManager movMgr = new MovieManager();
        private GameManager gamMgr = new GameManager();
        private List<Movie> movies = new List<Movie>();
        private List<Game> games = new List<Game>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
        }

        private void RefreshGamesForRental()
        {
            try
            {
                games = gamMgr.RetrieveGamesForRental();
            }
            catch (Exception)
            {

                MessageBox.Show("There was an error retrieving games for rental");
            }

            LstMediaList.Items.Clear();

            foreach (var game in games)
            {
                LstMediaList.Items.Add(game.Title + " - In Stock:  " + game.QuantityAvailable);
            }
        }

        private void RefreshMoviesForRent()
        {
            
            try
            {
                movies = movMgr.RetrieveMoviesForRent();
                
            }
            catch (Exception)
            {

                MessageBox.Show("There was an error retrieving your movies");
            }

            LstMediaList.Items.Clear();

            foreach (var movie in movies)
            {
                LstMediaList.Items.Add(movie.Title + " - In Stock:  " + movie.QuantityAvailable);
            }


            //var description = LstMediaList.Items.Add(movies[3]);

        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Launches a login window
            var _login = new Login();
           

            if ((string)btnLogIn.Content == "Log Out")
            {
                MessageBox.Show("Logged out");
                btnLogIn.Content = "Log In";
            }
            else if((string)btnLogIn.Content == "Log In")
            {                
                _login.ShowDialog();
                btnLogIn.Content = "Log Out";
            }
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Terminating Program...");
            this.Close();
        }

        private void mnuAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = new AdminLogin();
            login.ShowDialog();
        }

        private void cmbMovies_Selected(object sender, RoutedEventArgs e)
        {
            RefreshMoviesForRent();
        }

        private void cmbVideoGames_Selected(object sender, RoutedEventArgs e)
        {
            RefreshGamesForRental();
        }
    }
}
