using System;
using System.Collections.Generic;
using System.Linq;
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

            var imgRegex = new Regex(".(jpg|png|gif|bmp)$");
            if (!imgRegex.IsMatch(card.FrontImgURL))
            {
                card.FrontImgURL = null;
            }
            if (!imgRegex.IsMatch(card.BackImgURL))
            {
                card.BackImgURL = null;
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
            var model = db.Sets.Where(s => s.Id == Id).Select(c => new
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


    }
}