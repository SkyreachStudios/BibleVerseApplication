using BibleVerseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApp.Controllers
{
    public class HomeController : Controller
    {
        //Navigate to Home/Main page
        public ActionResult Index()
        {
            return View();
        }
        //Naviagte to Insert Page
        public ActionResult Insert()
        {
            

            return View("~/Views/Insert/Insert.cshtml");
        }
        //navigate to Search page
        public ActionResult Search()
        {
            
            

            return View("~/Views/Search/Search.cshtml");
        }


    }
}