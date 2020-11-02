using BibleVerseApp.Models;
using BibleVerseApp.Services.Business;
using BibleVerseApp.Utilities.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApp.Controllers
{
    public class SearchController : Controller
    {
       
        public ILogger logger { get; set; }
        public SearchService searchService { get; set; }
       
    

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //method which accesses the SearchService utility and dependent on the value received will sets the
        //model values to the coresponding values.
        public ActionResult Search (VerseModel model)
        {
            logger = new MyLogger();
            SearchService service = new SearchService();
            if (service.Authenticate(model))
            {
                
                logger.Info("The given credentials returned a verse which exists in the database: " +model.Testament+ "|"+model.Book+"|"+model.Chapter+"|"+model.Verse+"|"+model.VerseText);
                model = service.changeValues(model);
                return View("~/Views/Search/Search.cshtml", model);
            }
            else
            {
                logger.Info("The given credentials did not exist in the database.");
                model.SearchStatus = 2;
                return View("~/Views/Search/Search.cshtml", model);
            }
            
            
        }
    }
}