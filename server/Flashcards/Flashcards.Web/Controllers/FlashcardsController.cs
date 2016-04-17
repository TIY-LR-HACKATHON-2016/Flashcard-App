﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Flashcards.Web.Models;

namespace Flashcards.Web.Controllers
{
    public class FlashcardsController : Controller
    {
        private FlashcardsDbContext db = new FlashcardsDbContext();

        [HttpPost]
        public ActionResult CreateCard(CreateCardVM card)
        {
            if (!ModelState.IsValid)
            {
                return Content("Nope (Bad Card Model)");
            }

            var newCard = new Card
            {
                frontText = card.frontText,
                backText = card.backText,
                FrontImgURL = card.FrontImgURL,
                BackImgURL = card.BackImgURL,
            };
            var set = db.Sets.Find(card.SetId);
            if (set == null)
            {
                return Content("That set isn't in the DB");
            }
            newCard.Set = set;

            var imgRegex = new Regex("(jpg|png|gif|bmp)$");
            if (card.FrontImgURL != null)
            {
                if (!imgRegex.IsMatch(card.FrontImgURL))
                {
                    card.FrontImgURL = null;
                }
            }
            if (card.BackImgURL != null)
            {
                if (!imgRegex.IsMatch(card.BackImgURL))
                {
                    card.BackImgURL = null;
                }
            }

            db.Cards.Add(newCard);
            db.SaveChanges();
            return Json(card, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateSet(CreateSetVM set)
        {
            if (!ModelState.IsValid)
            {
                return Content("Nope (Bad Set Model)");
            }
            var sub = db.Subjects.Find(set.SubjectId);
            if (sub == null)
            {
                return Content("Nope, that's not a vaild subject for this set");
            }

            var newSet = new Set
            {
                Name = set.Name,
                Subject = sub
            };
            if (set.ImgURL != null)
            {
                var imgRegex = new Regex(".(jpg|png|gif|bmp)$");
                if (imgRegex.IsMatch(set.ImgURL))
                {
                    newSet.ImgURL = set.ImgURL;
                }
            }
            db.Sets.Add(newSet);
            db.SaveChanges();
            return Json(set, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateSubject(CreateSubjectVM subject)
        {
            if (!ModelState.IsValid)
            {
                return Content("nope, subject in bad state");
            }
            var newSub = new Subject
            {
                Name = subject.Name,
            };
            if (subject.ImgURL != null)
            {
                var imgRegex = new Regex(".(jpg|png|gif|bmp)$");
                if (imgRegex.IsMatch(subject.ImgURL))
                {
                    newSub.ImgURL = subject.ImgURL;
                }
            }
            db.Subjects.Add(newSub);
            db.SaveChanges();
            return Json(subject, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult ViewSet(int Id)
        {
            var model = db.Cards.Where(s=>s.Set.Id==Id).Select(c => new {
                fronttext = c.frontText,
                backtext = c.backText,
                id = c.Id,
                frontimg = c.FrontImgURL,
                backimg = c.BackImgURL
            }).ToList();
            if (model.Count == 0)
            {
                return Content("nope, that's not a set");
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult ViewSubject(int Id)
        {
            var model = db.Sets.Where(s => s.Subject.Id == Id).Select(c => new
            {
                name = c.Name,
                id = c.Id,
                count = c.Cards.Count
            }).ToList();
            if (model.Count== 0)
            {
                return Content("nope, that's not a subject");
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        
        public ActionResult ViewCard(int Id)
        {
            var card = db.Cards.Find(Id);
            if (card == null)
            {
                return Content("nope, that's not a card");
            }
            var model = new
            {
                fronttext = card.frontText,
                backtext = card.backText,
                id = card.Id,
                frontimg = card.FrontImgURL,
                backimg = card.BackImgURL
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult IndexSubject()
        {
            var model = db.Subjects.Select(x => new
            {
                name= x.Name,
                id = x.Id,
                count = x.Sets.Count
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

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
        public ActionResult EditSet(Set set)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            db.Cards.Remove(card);
            db.SaveChanges();
            
            return Content("Deleted Card");
        }

        [HttpPost]
        public ActionResult DeleteSet(int? id)
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

            db.Sets.Remove(set);
            db.SaveChanges();

            return Content("Deleted Set");
        }

        [HttpPost]
        public ActionResult DeleteSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return Content("Why for 404?");
            }

            db.Subjects.Remove(subject);
            db.SaveChanges();

            return Content("Deleted Subject");
        }


    }
}