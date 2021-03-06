﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                var imgRegex = new Regex("(jpg|png|gif|bmp)$");
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
                var imgRegex = new Regex("(jpg|png|gif|bmp)$");
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
            var model = db.Sets.Find(Id).Cards.Select(c => new
            {
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
            var model = db.Subjects.Find(Id).Sets.Select(s => new
            {
                name = s.Name,
                id = s.Id,
                count = s.Cards.Count
            }).ToList();
            if (model.Count == 0)
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
                name = x.Name,
                id = x.Id,
                count = x.Sets.Count
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Edit 
        [HttpPost]
        public ActionResult EditCard(EditCardVM editCard)
        {
            if (ModelState.IsValid)
            {
                var newCard = db.Cards.Include("Set").FirstOrDefault(s => s.Id == editCard.Id);
                if (newCard == null)
                {
                    return Content("Sorry, Card not in DataBase)");
                }
               
                if (editCard.FrontImgURL != null)
                {
                    newCard.FrontImgURL = editCard.FrontImgURL;
                }
                if (editCard.BackImgURL != null)
                {
                    newCard.BackImgURL = editCard.BackImgURL;
                }
                if (editCard.frontText != null)
                {
                    newCard.frontText = editCard.frontText;
                }
                if (editCard.backText != null)
                {
                    newCard.backText = editCard.backText;
                }

                db.SaveChanges();

                var model =
                    new
                    {
                        newCard.backText,
                        newCard.frontText,
                        newCard.BackImgURL,
                        newCard.FrontImgURL,
                        newCard.Id
                    };

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return Content("Sorry, Card not in DataBase"); ;
        }

        [HttpPost]
        public ActionResult EditSet(EditSetVM editSet)
        {
            if (!ModelState.IsValid)
            {
                return Content("Not a valid set");
            }
            var newSet = db.Sets.Include("Subject").FirstOrDefault(s => s.Id == editSet.Id);
            if (newSet == null)
            {
                return Content("Sorry, Set not in DataBase)");
            }

            newSet.Name = editSet.Name;
            newSet.ImgURL = editSet.ImgURL;

            db.SaveChanges();

            var model =
                    new
                    {
                        newSet.Name,
                        newSet.ImgURL,
                        newSet.Id,

                    };

            return Json(model, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult EditSubject(EditSubjectVM editSubject)
        {
            var newSubject = db.Subjects.Find(editSubject.Id);

            if (newSubject == null)
            {
                return Content("Not a valid subject");
            }

            if (editSubject.Name != null)
            {
                newSubject.Name = editSubject.Name;
            }

            if (editSubject.ImgURL != null)
            {
                newSubject.ImgURL = editSubject.ImgURL;
            }

            db.SaveChanges();

            var model =
                   new
                   {
                       newSubject.Name,
                       newSubject.ImgURL,

                   };

            return Json(model, JsonRequestBehavior.AllowGet);
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

        public ActionResult AlphaCards()
        {
            var model = db.Cards.Select(x => new
            {
                fronttext = x.frontText,
                backtext = x.backText,
                id = x.Id,
                backimgurl = x.BackImgURL,
                frontimgurl = x.FrontImgURL
            }).OrderBy(c => c.fronttext);


            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}