
using LazerSharkDataObjects;
using LazerSharkDataObjects.Abstract;
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
        // GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { 
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        [Authorize]
        public RedirectToRouteResult AddMovieToCart(int? id)
        {
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)id);

            if (movie != null)
            {
                GetCart().AddMovie(movie, 1);
            }
            return RedirectToAction("Index");

        }

        [Authorize]
        public RedirectToRouteResult AddGameToCart(int? id)
        {
            Game game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)id);

            if (game != null)
            {
                GetCart().AddGame(game, 1);
            }
            return RedirectToAction("Index");
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


    }
}