using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flashcards.Web.Models;

namespace Flashcards.Web.Controllers
{
    public class CardsController : Controller
    {
        private FlashcardsDbContext db = new FlashcardsDbContext();

        // GET: Cards
        public ActionResult Index()
        {
            //var model = db.Sets.Select(s => new {Subject = s.Subject.Name, SetName = s.Name, CardCount = s.Cards.Count()}).ToList();
            var model = db.Cards.OrderBy(s=>s.Set.Id).Select(c=> new {fronttext = c.frontText, backtext =c.backText, id = c.Id,
                frontimg = c.FrontImgURL, backimg = c.BackImgURL}).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return Json(card, JsonRequestBehavior.AllowGet);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "frontText,backText")] Card card)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(card);
                db.SaveChanges();
                return Json(card, JsonRequestBehavior.AllowGet);
            }

            return Content("Nope (Bad Card Model)");
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,frontText,backText")] Card card)
        {
            if (ModelState.IsValid)
            {
                var newCard = db.Cards.Find(card.Id);
                if (newCard == null)
                {
                    return Content("Nope (Bad Card Model to edit)");
                }
                newCard.frontText = card.frontText;
                newCard.backText = card.backText;

                db.SaveChanges();
                return Json(card, JsonRequestBehavior.AllowGet);
            }
            return Content("Nope (Bad Card Model to edit)");
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}
