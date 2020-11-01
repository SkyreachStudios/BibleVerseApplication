using BibleVerseApp.Models;
using BibleVerseApp.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace BibleVerseApp.Services.Business
{
    public class SearchService
    {
        [Dependency]
        public SearchDAO searchDAO { get; set; }

        //method which calls the DAO function to find if the given verse is valid and return a true or false
        public bool Authenticate(VerseModel verse)
        {
           
            SearchDAO searchService = new SearchDAO();
            return searchService.findByVerse(verse);
        }
        //method which calls the DAO function to set the values and return the verse object
        public VerseModel changeValues(VerseModel verse)
        {
            SearchDAO searchService = new SearchDAO();
            return searchService.setToFoundVerse(verse);
        }
    }
}
