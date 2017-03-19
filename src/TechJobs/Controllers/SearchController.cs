using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.tilte = "Search";
            
            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobz = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobz;
                
            }
            else
            {
                List<Dictionary<string, string>> jobz = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobz;
            }
            return View("Views/Search/Index.cshtml");
        }
    }
}   
