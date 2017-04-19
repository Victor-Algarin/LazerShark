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
    public class GamesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        LazerSharkLogicLayer.IGameManager gamMgr = new LazerSharkLogicLayer.GameManager();

        // GET: /Games/
        public ActionResult Index()
        {
            return View(gamMgr.RetrieveGamesForRental());
        }

        // GET: /Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [Authorize(Roles="Administrator")]
        // GET: /Games/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles="Administrator")]
        // POST: /Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,GenreID,Description,Rating,MediumID,QuantityAvailable,Quantity,RentalPrice")] Game game)
        {
            if (ModelState.IsValid)
            {

                if (gamMgr.CreateGame(game) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable);
                }
            }

            return View(game);
        }

        [Authorize(Roles="Administrator")]
        // GET: /Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: /Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,Title,GenreID,Description,Rating,MediumID,QuantityAvailable,Quantity,RentalPrice,Active")] Game newGame)
        {
            if (ModelState.IsValid)
            {
                var oldGame = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)newGame.GameID);
                if (gamMgr.EditGame(oldGame, newGame) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }                
            }
            return View(newGame);
        }

        [Authorize(Roles="Administrator")]
        // GET: /Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = gamMgr.RetrieveGamesForRental().Find(g => g.GameID == (int)id);

            if (game == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (gamMgr.RemoveGamesFromKiosk(game.GameID) == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(game);
        }

        //// POST: /Games/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Game game = db.Games.Find(id);
        //    db.Games.Remove(game);
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
