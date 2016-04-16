using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashcards.Web.Controllers
{
    public class FlashcardsController : Controller
    {
        // GET: Flashcards
        public ActionResult Index()
        {
            return View();
        }
    }
}