using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LazerSharkDataObjects;
using MVCPresentationLayer.Models;

namespace MVCPresentationLayer.Controllers
{
    public class MoviesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        LazerSharkLogicLayer.IMovieManager movMgr = new LazerSharkLogicLayer.MovieManager();

        // GET: Movies
        public ActionResult Index()
        {
            return View(movMgr.RetrieveMoviesForRent());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Administrator")]
        public ActionResult Create([Bind(Include = "Title,GenreID,Description,Rating,MediumID,QuantityAvailable,Quantity,RentalPrice,Active")] Movie movie)
        {
            if (ModelState.IsValid)
            {       
                if (movMgr.CreateNewMovie(movie) == true)
                {
                    // Opens index
                    return RedirectToAction("Index");
                }
                else
                {
                    // returns error msg
                    return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
                }
            }

            return View(movie);
        }

        [Authorize(Roles="Administrator")]
        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Title,GenreID,Description,Rating,MediumID,QuantityAvailable,Quantity,RentalPrice,Active")] Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                var oldMovie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)newMovie.MovieID);


                // Should equal true, but does not... Why???
                if (movMgr.EditMovie(oldMovie, newMovie) == false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
                }
            }
            return View(newMovie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = movMgr.RetrieveMoviesForRent().Find(m => m.MovieID == (int)id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (movMgr.RemoveMovieFromKiosk(movie.MovieID))
                {
                    return RedirectToAction("Index");
                }
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        //// POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Movie movie = db.Movies.Find(id);
        //    db.Movies.Remove(movie);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
