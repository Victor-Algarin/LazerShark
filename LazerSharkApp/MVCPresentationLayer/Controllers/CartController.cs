
using LazerSharkDataObjects;
using LazerSharkLogicLayer;
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

        CartManager cart = new CartManager();

        public RedirectToRouteResult AddMovieToCart(int movieId, string returnUrl)
        {            
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)movieId);

            if (movie != null)
            {
                cart.AddMovie(movie, 1);
            }
            return RedirectToAction("Index", new { returnUrl });

        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}