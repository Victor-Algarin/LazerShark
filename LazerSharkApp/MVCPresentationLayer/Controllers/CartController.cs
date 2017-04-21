
using LazerSharkDataObjects;
using LazerSharkLogicLayer;
using MVCPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class CartController : Controller
    {
        IMovieManager movMgr = new MovieManager();
        IGameManager gamMgr = new GameManager();

        CartManager cart = new CartManager();

        [Authorize]
        public RedirectToRouteResult AddMovieToCart(int movieId, string returnUrl)
        {            
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)movieId);

            if (movie != null)
            {
                cart.AddMovie(movie, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        [Authorize]
        public RedirectToRouteResult AddGameToCart(int gameId, string returnUrl)
        {
            Game game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)gameId);

            if (game != null)
            {
                cart.AddGame(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [Authorize]
        public RedirectToRouteResult RemoveMovieFromCart(int movieId, string returnUrl)
        {
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)movieId);

            if (movie != null)
            {
                cart.RemoveMovie(movie);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [Authorize]
        public RedirectToRouteResult RemoveGameFromCart(int gameId, string returnUrl)
        {
            Game game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)gameId);

            if (game != null)
            {
                cart.RemoveGame(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private CartManager GetCart()
        {
            CartManager cart = (CartManager)Session["CartManager"];
            if (cart == null)
            {
                cart = new CartManager();
                Session["CartManager"] = cart;
            }
            return cart;
        }

        [Authorize]
        // GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { 
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}