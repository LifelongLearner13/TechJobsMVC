using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        private static string type = "all";
        private static string term = "";

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.searchType = type;
            ViewBag.searchTerm = term;
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            type = searchType;
            term = searchTerm;
            List<Job> jobs;
            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.searchType = type;
            ViewBag.searchTerm = term;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.jobs = jobs;


            return View("Index");
        }

    }
}
