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
    public class SubjectsController : Controller
    {
        private FlashcardsDbContext db = new FlashcardsDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var model = db.Subjects.Select(s => new { SubjectName = s.Name, setcount = s.Sets.Count()}).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("nope, need an Id");
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return Content("nope, subject not found");
            }
            return Json(subject, JsonRequestBehavior.AllowGet);
        }

        //// GET: Subjects/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return Json(subject, JsonRequestBehavior.AllowGet);
            }

            return Content("nope, subject in bad state");
        }

        // GET: Subjects/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Subject subject = db.Subjects.Find(id);
        //    if (subject == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subject);
        //}

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return Content("nope, subject in bad state");
            }
            var sub = db.Subjects.Find(subject.Id);
            if (sub == null)
            {
                return Content("subject not found");
            }
            sub.Name = subject.Name;
            db.SaveChanges();
            return Json(subject, JsonRequestBehavior.AllowGet);
        }

        // GET: Subjects/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Subject subject = db.Subjects.Find(id);
        //    if (subject == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subject);
        //}

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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
