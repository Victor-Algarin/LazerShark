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
    /// Interaction logic for AdminUI.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        List<Movie> movies = new List<Movie>();
        List<Game> games = new List<Game>();
        MovieManager movMgr = new MovieManager();
        GameManager gamMgr = new GameManager();
        int kioskId = 100001;
        int adminId = 100001;
        Movie movieSelection;
        Game gameSelection;
        int movieId;
        int gameId;

        public AdminUI()
        {

            InitializeComponent();
            movies = movMgr.RetrieveMoviesByKioskIdAndAdminId(kioskId, adminId);
            games = gamMgr.RetrieveGamesInKiosk(kioskId, adminId);
            refreshGames();
            refreshMovies();
        }




        private void refreshGames()
        {
            games = gamMgr.RetrieveGamesInKiosk(kioskId, adminId);
            
            lstGameList.Items.Clear();
            foreach (var game in games)
            {
                lstGameList.Items.Add(game.Title + " - In Stock:  " + game.QuantityAvailable);
            }  
        }

        private void refreshMovies()
        {
            movies = movMgr.RetrieveMoviesByKioskIdAndAdminId(kioskId, adminId);

            lstMovieList.Items.Clear();
          foreach (var movie in movies)
            {
                lstMovieList.Items.Add(movie.Title + " - In Stock:  " + movie.QuantityAvailable + "  " + movie.MovieID);
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            AdminOrderUI orderUI = new AdminOrderUI();
            Close();
            orderUI.ShowDialog();
            
        }

        private void btnRemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            if (lstMovieList.SelectedIndex != -1)
            {
                setMovieId();
            }
            

            if (movMgr.RemoveMovieFromKiosk(movieId) == true)
            {
                try
                {
                    
                    lstMovieList.Items.Remove(movieSelection);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
            
            refreshMovies();
        }

        private void setMovieId()
        {
            movieSelection = (from movie in movies
                              where ((string)lstMovieList.SelectedItem).Contains(movie.Title)
                              select movie).First();
            this.movieId = movieSelection.MovieID;
            
        }

        private void btnRemoveGame_Click(object sender, RoutedEventArgs e)
        {
            if (lstGameList.SelectedIndex != -1)
            {
                setGameId();
            }

            
            if (gamMgr.RemoveGamesFromKiosk(gameId) == true)
            {
                try
                {
                    
                    lstMovieList.Items.Remove(gameSelection);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            refreshGames();

        }

        private void setGameId()
        {
            try
            {
                gameSelection = (from game in games
                                 where ((string)lstGameList.SelectedItem).Contains(game.Title)
                                 select game).First();
                gameId = gameSelection.GameID;
                
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong...");
            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow main = new MainWindow();
            Close();
            main.ShowDialog();
        }
    }
}
