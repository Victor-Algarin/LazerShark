
using LazerSharkDataObjects;
using LazerSharkDataObjects.Abstract;
using LazerSharkLogicLayer;
using MVCPresentationLayer.Entities;
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

        Cart cart = new Cart();

        [Authorize]
        // GET: Cart
        public ViewResult Index()
        {
            return View(new CartIndexViewModel { 
                Cart = GetCart()
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
        public RedirectToRouteResult RemoveMovieFromCart(int? movieId)
        {
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)movieId);

            if (movie != null)
            {
                GetCart().RemoveMovie(movie);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToRouteResult RemoveGameFromCart(int? gameId)
        {
            Game game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)gameId);

            if (game != null)
            {
                cart.RemoveGame(game);
            }
            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["CartManager"];
            if (cart == null)
            {
                cart = new Cart();
                Session["CartManager"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {

            CheckoutModel model = new CheckoutModel() {};
            var cart = GetCart();
            
            foreach (var item in cart.Lines)
            {
                model.Movies.Add(item.Movie);
            }
            //foreach (var item in cart.Lines)
            //{
            //    model.games.Add(item.Game);
            //}

            return View(model);
        }


    }
}