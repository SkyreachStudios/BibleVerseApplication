using BibleVerseApp.Models;
using BibleVerseApp.Utilities.Business;
using BibleVerseApp.Utilities.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace BibleVerseApp.Controllers
{
    public class InsertController : Controller
    {
        [Dependency]
        public VerseService verseService { get; set; }
        public ILogger logger { get; set; }

        // GET: Insert
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(VerseModel model)
        {
            if (verseService.CreateVerse(model))
            {
                return View("AddedVerse");
            }
            else
            {
                return View("AddFailed");
            }
        }


    }
}