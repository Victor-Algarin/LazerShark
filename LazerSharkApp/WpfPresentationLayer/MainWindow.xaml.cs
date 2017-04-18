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
        private MediaManager medMgr = new MediaManager();        
        private List<Movie> movies = new List<Movie>();
        private List<Movie> finalMovieSelection = new List<Movie>();
        private List<Game> games = new List<Game>();
        private List<Game> finalGameSelection = new List<Game>();
        private decimal total = 0;
        private decimal moviePrice;
        private decimal gamePrice;
        private Movie movieSelection;
        private Game gameSelection;
        bool loggedIn = false;

        public MainWindow()
        {
            InitializeComponent();          
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hideGameFilters();
            showMovieFilters();
        }

        private void RefreshGamesForRental()
        {
            // clears the current listing of all items
            lstMediaList.Items.Clear();

            // displays all of the available games by title and add them to the media listing
            foreach (var game in games)
            {
                lstMediaList.Items.Add(game.Title + " - $" + game.RentalPrice);
            }
        }

        private void RefreshMoviesForRent()
        {
            // clears the current listing of all items
            lstMediaList.Items.Clear();

            // displays all of the available movies by title and add them to the media listing
            foreach (var movie in movies)
            {
                lstMediaList.Items.Add(movie.Title + " - $" + movie.RentalPrice);
            }
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Launches a login window
            var login = new Login();

            // If the user is currently logged in, the button content will change to log out 
            if (loggedIn == false)
            {
                btnLogIn.Content = "Log In";
                login.ShowDialog();
                loggedIn = login.sendLoginStatus();
                if (loggedIn == true)
                {
                    btnLogIn.Content = "Log Out";
                }
            }
            // If the user hasn't logged in, the button content will display "log in"
            // and route to the login window when clicked
            else
            {
                MessageBox.Show("Logged out");
                loggedIn = false;
                btnLogIn.Content = "Log In";
            }
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            // this button quits the program when clicked
            MessageBox.Show("Terminating Program...");
            Application.Current.Shutdown();
        }

        private void mnuAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            // this login menu item will open the login screen for administrators
            // customers will login through the login button on the main window only
            var login = new AdminLogin();
            Close();
            login.ShowDialog();
                        
        }

        private void cmbMovies_Selected(object sender, RoutedEventArgs e)
        {
            // this event validates if movies were the selected media and will attempt to 
            // retrieve movies from the logic layer in order to list the available titles
            try
            {
                movies = movMgr.RetrieveMoviesForRent();
            }
            catch (Exception)
            {

                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }
            try
            {
                if (cmbMovies.IsSelected == true)
                {
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }
            }
            catch (Exception)
            {
                
            }


            // After updating the movie listing, the search filters that are game specific 
            // will be removed from the combo boxes
            RefreshMoviesForRent();
            hideGameFilters();
            showMovieFilters();
        }

        private void cmbVideoGames_Selected(object sender, RoutedEventArgs e)
        {
            // this event validates if games were the selected media and will attempt to 
            // retrieve games from the logic layer in order to list the available titles
            try
            {
                games = gamMgr.RetrieveGamesForRental();
            }
            catch (Exception)
            {

                MessageBox.Show("There was an error retrieving games for rental");
            }

            // After updating the movie listing, the search filters that are movie specific 
            // will be removed from the combo boxes

            RefreshGamesForRental();
            cmbGenre.SelectedIndex = -1;
            cmbGenre.Text = "-- Select a Genre --";
            cmbMedium.SelectedIndex = -1;
            cmbMedium.Text = "-- Select System --";
            showGameFilters();
            hideMovieFilters();
        }

        private void cmbAction_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Action' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "Action";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '0' is 'Movies', index '1' is for 'Games'
                if (cmbCategory.SelectedIndex == 0 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    movies = movMgr.RetrieveMoviesByGenre(genreId);
                    RefreshMoviesForRent();
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbAction.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    mediumId = "Blu-Ray";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                    RefreshMoviesForRent();
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbAction.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    mediumId = "DVD";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                    RefreshMoviesForRent();
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    mediumId = "XBONE";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                    RefreshGamesForRental();
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    mediumId = "PS4";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                    RefreshGamesForRental();
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbPc.IsSelected == true)
                {
                    mediumId = "PC";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                    RefreshGamesForRental();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }


        }

        private void cmbDrama_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Drama' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "Drama";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '0' is 'Movies'
                if (cmbCategory.SelectedIndex == 0 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    movies = movMgr.RetrieveMoviesByGenre(genreId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbDrama.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    mediumId = "Blu-Ray";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbDrama.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    mediumId = "DVD";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbShooter.IsSelected == true || cmbSimulation.IsSelected == true || cmbRpg.IsSelected == true || cmbPs4.IsSelected == true || cmbPc.IsSelected == true || cmbXbox.IsSelected == true)
                {
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }
            RefreshMoviesForRent();
        }

        private void cmbComedy_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Comedy' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "Comedy";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '0' is 'Movies'
                if (cmbCategory.SelectedIndex == 0 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    movies = movMgr.RetrieveMoviesByGenre(genreId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbComedy.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    mediumId = "Blu-Ray";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbComedy.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    mediumId = "DVD";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbShooter.IsSelected == true || cmbSimulation.IsSelected == true || cmbRpg.IsSelected == true || cmbPs4.IsSelected == true || cmbPc.IsSelected == true || cmbXbox.IsSelected == true)
                {
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }
            RefreshMoviesForRent();
        }

        private void cmbDvd_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'DVD' search filter has been 
            // selected and will display all titles meeting the criteria below
            string mediumId = "DVD";
            string genreId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '0' is 'Movies'
                if (cmbCategory.SelectedIndex == 0 && cmbGenre.SelectedIndex == -1)
                {
                    // The medium selection will be sent to the logic layer for processing and retrieval
                    movies = movMgr.RetrieveMoviesByMedium(mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbComedy.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    genreId = "Comedy";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbAction.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    genreId = "Action";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbDrama.IsSelected == true && cmbDvd.IsSelected == true)
                {
                    genreId = "Drama";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbShooter.IsSelected == true || cmbSimulation.IsSelected == true || cmbRpg.IsSelected == true || cmbPs4.IsSelected == true || cmbPc.IsSelected == true || cmbXbox.IsSelected == true)
                {
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }
            RefreshMoviesForRent();

        }

        private void cmbBluRay_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'DVD' search filter has been 
            // selected and will display all titles meeting the criteria below
            string mediumId = "Blu-Ray";
            string genreId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '0' is 'Movies'
                if (cmbCategory.SelectedIndex == 0 && cmbGenre.SelectedIndex == -1)
                {
                    // The medium selection will be sent to the logic layer for processing and retrieval
                    movies = movMgr.RetrieveMoviesByMedium(mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbComedy.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    genreId = "Comedy";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbAction.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    genreId = "Action";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbDrama.IsSelected == true && cmbBluRay.IsSelected == true)
                {
                    genreId = "Drama";
                    movies = movMgr.RetrieveMoviesWithGenreAndMedium(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 0 && cmbShooter.IsSelected == true || cmbSimulation.IsSelected == true || cmbRpg.IsSelected == true || cmbPs4.IsSelected == true || cmbPc.IsSelected == true || cmbXbox.IsSelected == true)
                {
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }

            }
            catch (Exception)
            {
                MessageBox.Show("There was an error retrieving your movie selection criteria");
            }
            RefreshMoviesForRent();
        }

        private void cmbShooter_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Shooter' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "Shooter";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByGenreID(genreId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    mediumId = "XBONE";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    mediumId = "PS4";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbPc.IsSelected == true)
                {
                    mediumId = "PC";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void cmbSimulation_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Simulation' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "Simulation";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByGenreID(genreId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    mediumId = "XBONE";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    mediumId = "PS4";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbPc.IsSelected == true)
                {
                    mediumId = "PC";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void cmbRpg_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'RPG' search filter has been 
            // selected and will display all titles meeting that criteria
            string genreId = "RPG";
            string mediumId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbMedium.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByGenreID(genreId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    mediumId = "XBONE";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    mediumId = "PS4";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbPc.IsSelected == true)
                {
                    mediumId = "PC";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void cmbXbox_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'Xbox' search filter has been 
            // selected and will display all titles meeting that criteria
            string mediumId = "XBONE";
            string genreId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbGenre.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByMediumId(mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    genreId = "Shooter";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    genreId = "Simulation";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    genreId = "RPG";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbXbox.IsSelected == true)
                {
                    genreId = "Action";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void cmbPs4_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'PS4' search filter has been 
            // selected and will display all titles meeting that criteria
            string mediumId = "PS4";
            string genreId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbGenre.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByMediumId(mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    genreId = "Shooter";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    genreId = "Simulation";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    genreId = "RPG";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbPs4.IsSelected == true)
                {
                    genreId = "Action";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void cmbPc_Selected(object sender, RoutedEventArgs e)
        {
            // This event will react and validate whenever the 'PC' search filter has been 
            // selected and will display all titles meeting that criteria
            string mediumId = "PC";
            string genreId;

            try
            {
                // cmbCategory.SelectedIndex is the media type combobox,
                // index '1' is 'Games'
                if (cmbCategory.SelectedIndex == 1 && cmbGenre.SelectedIndex == -1)
                {
                    // The genre selection will be sent to the logic layer for processing and retrieval
                    games = gamMgr.RetrieveGamesByMediumId(mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbShooter.IsSelected == true && cmbPc.IsSelected == true)
                {
                    genreId = "Shooter";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbSimulation.IsSelected == true && cmbPc.IsSelected == true)
                {
                    genreId = "Simulation";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbRpg.IsSelected == true && cmbPc.IsSelected == true)
                {
                    genreId = "RPG";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
                else if (cmbCategory.SelectedIndex == 1 && cmbAction.IsSelected == true && cmbPc.IsSelected == true)
                {
                    genreId = "Action";
                    games = gamMgr.RetrieveGamesWithGenreAndMediumFilter(genreId, mediumId);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error meeting your game selection criteria");
            }
            RefreshGamesForRental();
        }

        private void LstMediaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // This event changes the description text everytime a new title is clicked on from the media list
            try
            {

                // Case 0 means movies are the selected category
                // Case 1 means games are the selected category
                switch (cmbCategory.SelectedIndex)
                {
                    case 0:
                        txtDescription.Clear();
                        populateDescriptionWithMovie();
                        break;
                    case 1:
                        txtDescription.Clear();
                        populateDescriptionWithGame();
                        break;
                    default:
                        txtDescription.Text = null;
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (lstCart.SelectedIndex != -1)
            {
                //MessageBox.Show("You must select an item from the list movies or games");
                lstCart.SelectedIndex = -1;
            }
            // The if statement validates whether the user has selected something to add to the cart
            else if (lstMediaList.Items.IsEmpty)
            {
                MessageBox.Show("You must select a movie or game to add to the cart");
            }
            else
            {
                // Case 0 means movies are the selected category
                // Case 1 means games are the selected category
                switch (cmbCategory.SelectedIndex)
                {
                    case 0:
                        populateCartWithMovie();
                        break;

                    case 1:
                        populateCartWithGame();
                        break;

                    default:
                        break;
                }
            }



            this.total = medMgr.sumPrices();
            txtTotal.Text = "$" + total.ToString();

        }

        private void populateDescriptionWithMovie()
        {
            txtDescription.Clear();
            var movieSelection = (from movie in movies
                                  where ((string)lstMediaList.SelectedItem).Contains(movie.Title)
                                  select movie).First();
            txtDescription.Text = movieSelection.Description + "\n\nRated: " + movieSelection.Rating + "\nSystem: " + movieSelection.MediumID + "\nAvailable: " + movieSelection.QuantityAvailable;

        }

        private void populateCartWithMovie()
        {

            try
            {
                movieSelection = (from movie in movies
                                  where ((string)lstMediaList.SelectedItem).Contains(movie.Title)
                                  select movie).First();
                lstCart.Items.Add(movieSelection.Title + " $" + movieSelection.RentalPrice);
                finalMovieSelection.Add(movieSelection);
                moviePrice = movieSelection.RentalPrice;
                medMgr.CalculateMoviesTotal(moviePrice);          
                
            }
            catch (Exception)
            {

                MessageBox.Show("You must select something to add to the cart...");
            }


            


        }

        private void populateDescriptionWithGame()
        {
            txtDescription.Clear();
            var gameSelection = (from game in games
                                 where ((string)lstMediaList.SelectedItem).Contains(game.Title)
                                 select game).First();
            txtDescription.Text = gameSelection.Description + "\n\nRated: " + gameSelection.Rating + "\nSystem: " + gameSelection.MediumID + "\nAvailable: " + gameSelection.QuantityAvailable;
        }

        private void populateCartWithGame()
        {
            try
            {
                this.gameSelection = (from game in games
                                      where ((string)lstMediaList.SelectedItem).Contains(game.Title)
                                      select game).First();
                lstCart.Items.Add(gameSelection.Title + " $" + gameSelection.RentalPrice);
                finalGameSelection.Add(gameSelection);
                gamePrice = gameSelection.RentalPrice;

                medMgr.CalculateGamesTotal(gamePrice);
            }
            catch (Exception)
            {

                MessageBox.Show("You must select something to add to the cart...");
            }


        }

        private void hideGameFilters()
        {
            if (cmbGenre != null && cmbMedium != null)
            {
                // When this method is called, the game search filters will be removed from the comboboxes
                cmbRpg.Visibility = Visibility.Collapsed;
                cmbShooter.Visibility = Visibility.Collapsed;
                cmbSimulation.Visibility = Visibility.Collapsed;
                cmbPc.Visibility = Visibility.Collapsed;
                cmbPs4.Visibility = Visibility.Collapsed;
                cmbXbox.Visibility = Visibility.Collapsed;
            }

        }

        private void showGameFilters()
        {
            if (cmbGenre != null && cmbMedium != null)
            {
                // when this method is called, the game search filters will be added to the comboboxes
                cmbRpg.Visibility = Visibility.Visible;
                cmbShooter.Visibility = Visibility.Visible;
                cmbSimulation.Visibility = Visibility.Visible;
                cmbPc.Visibility = Visibility.Visible;
                cmbPs4.Visibility = Visibility.Visible;
                cmbXbox.Visibility = Visibility.Visible;
            }
        }

        private void hideMovieFilters()
        {
            if (cmbGenre != null && cmbMedium != null)
            {
                // When this method is called, the movie search filters will be removed from the comboboxes
                cmbBluRay.Visibility = Visibility.Collapsed;
                cmbDvd.Visibility = Visibility.Collapsed;
                cmbComedy.Visibility = Visibility.Collapsed;
                cmbDrama.Visibility = Visibility.Collapsed;
            }
        }

        private void showMovieFilters()
        {
            if (cmbGenre != null && cmbMedium != null)
            {
                // when this method is called, the movie search filters will be added to the comboboxes
                cmbBluRay.Visibility = Visibility.Visible;
                cmbDvd.Visibility = Visibility.Visible;
                cmbComedy.Visibility = Visibility.Visible;
                cmbDrama.Visibility = Visibility.Visible;
            }
        }

        private void btnClearCart_Click(object sender, RoutedEventArgs e)
        {
            CheckOut checkOut = new CheckOut();
            if (lstCart.SelectedItem == null)
            {
                this.total = 0;
                medMgr.clearTotal();
                txtTotal.Text = total.ToString();
                lstCart.Items.Clear();
                finalGameSelection.Clear();
                finalMovieSelection.Clear();
            }
            else
            {
                removeMovie();
                removeGameFromCheckOutList();
                if (gamePrice == 0)
                {
                    total += (moviePrice);
                    
                }
                else if (moviePrice == 0)
                {
                    total += (gamePrice);
                    
                }
                else
                {
                    total = medMgr.sumPrices();
                }

                txtTotal.Text = total.ToString();
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);
            }                


        }

        private void removeMovie()
        {
            try
            {
                movieSelection = (from movie in movies
                              where ((string)lstCart.SelectedItem).Contains(movie.Title)
                              select movie).First();
                finalMovieSelection.Remove(movieSelection);
                moviePrice = movieSelection.RentalPrice * -1;
                medMgr.CalculateMoviesTotal(moviePrice);
            }
            catch (Exception)
            {

            }

        }

        private void removeGameFromCheckOutList()
        {
            try
            {
                gameSelection = (from game in games
                             where ((string)lstCart.SelectedItem).Contains(game.Title)
                             select game).First();
                finalGameSelection.Remove(gameSelection);
                gamePrice = gameSelection.RentalPrice *-1;
                medMgr.CalculateGamesTotal(gamePrice);
            }
            catch (Exception)
            {

            }

        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            CheckOut checkOut = new CheckOut();

            if (lstCart.Items.Count == 0)
            {

                MessageBox.Show("Nothing in cart");

            }
            else if (loggedIn == false)
            {
                MessageBox.Show("You must be logged in before checking out...");
            }
            else
            {


                checkOut.populateMoviesToConfirmationList(finalMovieSelection);
                checkOut.populateGamesToConfirmationList(finalGameSelection);
                total = medMgr.sumPrices();
                checkOut.displayTotal(total);
                checkOut.ShowDialog();

            }
        }

        private void cmbAll1_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbCategory.Focus();
                if (cmbCategory.SelectedIndex == 0)
                {

                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                    movies = movMgr.RetrieveMoviesForRent();
                    RefreshMoviesForRent();

                }
                else
                {

                    games = gamMgr.RetrieveGamesForRental();
                    RefreshGamesForRental();
                    cmbGenre.SelectedIndex = -1;
                    cmbGenre.Text = "-- Select a Genre --";
                    cmbMedium.SelectedIndex = -1;
                    cmbMedium.Text = "-- Select System --";
                }

            }
            catch (Exception)
            {                
            }
        }

        private void cmbAll2_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbAll2.IsSelected = false;
                cmbCategory.Focus();
                if (cmbCategory.SelectedIndex == 0)
                {
                    movies = movMgr.RetrieveMoviesForRent();
                    RefreshMoviesForRent();
                }
                else
                {
                    games = gamMgr.RetrieveGamesForRental();
                    RefreshGamesForRental();
                }

            }
            catch (Exception)
            {
            }
            cmbGenre.SelectedIndex = -1;
            cmbGenre.Text = "-- Select a Genre --";
            cmbMedium.SelectedIndex = -1;
            cmbMedium.Text = "-- Select System --";
        }

        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCart.SelectedIndex != -1)
            {
                btnClearCart.Content = "Remove Item";
            }
            else
            {
                btnClearCart.Content = "Clear Cart";
            }
        }
    }
}
