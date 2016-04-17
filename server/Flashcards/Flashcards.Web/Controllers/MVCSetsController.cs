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
    public class MVCSetsController : Controller
    {
        private FlashcardsDbContext db = new FlashcardsDbContext();

        // GET: MVCSets
        public ActionResult Index()
        {
            return View(db.Sets.ToList());
        }

        // GET: MVCSets/Details/5
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
            return View(set);
        }

        // GET: MVCSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImgURL")] Set set)
        {
            if (ModelState.IsValid)
            {
                db.Sets.Add(set);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(set);
        }

        // GET: MVCSets/Edit/5
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

        // POST: MVCSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImgURL")] Set set)
        {
            if (ModelState.IsValid)
            {
                db.Entry(set).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(set);
        }

        // GET: MVCSets/Delete/5
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

        // POST: MVCSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Set set = db.Sets.Find(id);
            db.Sets.Remove(set);
            db.SaveChanges();
            return RedirectToAction("Index");
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
