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
    public class SetsController : Controller
    {
        private FlashcardsDbContext db = new FlashcardsDbContext();

        // GET: Sets
        public ActionResult Index()
        {
            var model = db.Sets.Select(s => new { setname = s.Name, setcount = s.Cards.Count() }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Sets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return Json(set, JsonRequestBehavior.AllowGet);

        }

        // GET: Sets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Set set)
        {
            if (ModelState.IsValid)
            {
                db.Sets.Add(set);
                db.SaveChanges();
                return Json(set, JsonRequestBehavior.AllowGet);
            }

            return Content("Nope (Bad Set Model)");
        }

        // GET: Sets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }

        // POST: Sets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Set set)
        {

            if (ModelState.IsValid)
            {
                var newSet = db.Sets.Find(set.Id);
                if (newSet == null)
                {
                    return Content("Nope (Bad Set Model to edit)");
                }
                newSet = set;

                db.SaveChanges();
                return Json(set, JsonRequestBehavior.AllowGet);
            }
            return Content("Nope (Bad Set Model to edit)");
        }

        // GET: Sets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }

        // POST: Sets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Set set = db.Sets.Find(id);
            db.Sets.Remove(set);
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
