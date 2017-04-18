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
    /// Interaction logic for AdminOrderUI.xaml
    /// </summary>
    public partial class AdminOrderUI : Window
    {
        List<Movie> movies = new List<Movie>();
        MovieManager movMgr = new MovieManager();
        List<Game> games = new List<Game>();
        GameManager gamMgr = new GameManager();
        Movie movieSelection;
        Game gameSelection;
        int movieId;
        int gameId;
        int supplierId;

        public AdminOrderUI()
        {
            InitializeComponent();
            
        }

        public void GetSupplierMovies()
        {
            try
            {
                movies = movMgr.GetSupplierMovieStock(supplierId);
                foreach (var movie in movies)
                {
                    lstMovies.Items.Add(movie.Title);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong when retrieving movies from supplier");
            }
            

        }

        public void GetSupplierGames()
        {
            try
            {
                games = gamMgr.RetrieveSupplierGamesStock(supplierId);
                foreach (var game in games)
                {
                    lstGames.Items.Add(game.Title);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong when retrieving games from supplier");
            }
            

        }

        private void radCJ_Checked(object sender, RoutedEventArgs e)
        {
            supplierId = 100000;
            lstMovies.Items.Clear();
            lstGames.Items.Clear();
            GetSupplierMovies();
            GetSupplierGames();

        }

        private void radWholeSale_Checked(object sender, RoutedEventArgs e)
        {
            supplierId = 100001;
            lstMovies.Items.Clear();
            lstGames.Items.Clear();
            GetSupplierMovies();
            GetSupplierGames();
        }

        private void radDa_Checked(object sender, RoutedEventArgs e)
        {
            supplierId = 100002;
            lstMovies.Items.Clear();
            lstGames.Items.Clear();
            GetSupplierMovies();
            GetSupplierGames();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            setGameId();
            setMovieId();

            if (lstMovies.SelectedIndex != -1 && movMgr.AddMoviesToKiosk(movieId) == true)
            {
                try
                {
                    MessageBox.Show(movieSelection.Title + " has been added to the kiosk");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else if (lstGames.SelectedIndex != -1 && gamMgr.AddGamesToKiosk(gameId) == true)
            {
                try
                {
                    MessageBox.Show(gameSelection.Title + " has been added to the kiosk");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void setMovieId()
        {
            try
            {
            movieSelection = (from movie in movies
                              where ((string)lstMovies.SelectedItem).Contains(movie.Title)
                              select movie).First();
            this.movieId = movieSelection.MovieID;
            }
            catch (Exception)
            {

                
            }
        }


        private void setGameId()
        {
            try
            {
            gameSelection = (from game in games
                             where ((string)lstGames.SelectedItem).Contains(game.Title)
                             select game).First();
            gameId = gameSelection.GameID;
            }
            catch (Exception)
            {

               
            }

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            AdminUI adminUI = new AdminUI();
            Close();
            adminUI.ShowDialog();
        }
    }
}
