using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flashcards.Web.Models;

namespace Flashcards.Web.Controllers
{
    public class FlashcardsController : Controller
    {
        // GET: Flashcards
        private FlashcardsDbContext db = new FlashcardsDbContext();

        //Edit 
        [HttpPost]
        public ActionResult EditCard([Bind(Include = "frontText, backText, FrontImgURL, BackImgURL, Id")] Card card)
        {
            if (ModelState.IsValid)
            {
                var newCard = db.Cards.Find(card.Id);
                if (newCard == null)
                {
                    return Content("Sorry,1 Card not in DataBase)");
                }

                newCard.FrontImgURL = card.FrontImgURL;
                newCard.BackImgURL = card.BackImgURL;
                newCard.frontText = card.frontText;
                newCard.backText = card.backText;
                newCard.Id = card.Id;

                db.SaveChanges();
                return Json(card, JsonRequestBehavior.AllowGet);
            }
            return Json(card, JsonRequestBehavior.AllowGet); ;

            
        }

        [HttpPost]
        public ActionResult EditSet( Set set)
        {
            var newSet = db.Sets.Find(set.Id);
            //Set newSet = db.Sets.Find(set);
            if (newSet == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            newSet.Id = set.Id;
            newSet.Name = set.Name;
           // newSet.ImgURL = set.ImgURL; 
           //TODO set img url
            db.SaveChanges();
            
            return Json(set, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditSubject([Bind(Include = "Name, Id")] Subject subject)
        {
            var newSubject = db.Subjects.Find(subject.Id);
            Subject newsubject = db.Subjects.Find(subject.Id);
            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            newSubject.Name = subject.Name;
            newSubject.Id = subject.Id;

            db.SaveChanges();
            if (newsubject == null)
            {
                return Content("Sorry,3 Subject is not in DataBase");
            }
            return Json(subject, JsonRequestBehavior.AllowGet);
        }


        //Delete
        [HttpPost]
        public ActionResult DeleteCard(int? id)
        {
            Card card = db.Cards.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.SaveChanges();
            if (card == null)
            {
                return HttpNotFound();
            }
            return Content("Sorry,4 Card not in DataBase");
        }

        [HttpPost]
        public ActionResult DeleteSet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Set set = db.Sets.Find(id);
            db.SaveChanges();
            if (set == null)
            {
                return HttpNotFound();
            }
            return Content("Sorry,5 Set is not in DataBase");
        }

        [HttpPost]
        public ActionResult DeleteSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            db.SaveChanges();
            if (subject == null)
            {
                return HttpNotFound();
            }
            return Content("Sorry,6 Subject is not in DataBase");
        }
    }
}