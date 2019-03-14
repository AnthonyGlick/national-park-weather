using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDao;
        private ISurveyDAO surveyDao;

        public HomeController (IParkDAO parkDao, ISurveyDAO surveyDao)
        {
            this.parkDao = parkDao;
            this.surveyDao = surveyDao;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDao.GetParks();
            return View(parks);
        }

        public IActionResult Detail(string id)
        {
            Park park = parkDao.GetPark(id);
            return View(park);
        }

        [HttpGet]
        public IActionResult Survey()
        {
            IList<Park> parks = parkDao.GetParks();
            ViewData["Parks"] = parks;

            IList<string> states = new List<string>()
            {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California",
                "Colorado",
                "Connecticut",
                "Delaware",
                "Florida",
                "Georgia",
                "Hawaii",
                "Idaho",
                "Illinois",
                "Indiana",
                "Iowa",
                "Kansas",
                "Kentucky",
                "Louisiana",
                "Maine",
                "Maryland",
                "Massachusetts",
                "Michigan",
                "Minnesota",
                "Mississippi",
                "Missouri",
                "Montana",
                "Nebraska",
                "Nevada",
                "New Hampshire",
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Ohio",
                "Oklahoma",
                "Oregon",
                "Pennsylvania",
                "Rhode Island",
                "South Carolina",
                "South Dakota",
                "Tennessee",
                "Texas",
                "Utah",
                "Vermont",
                "Virginia",
                "Washington",
                "West Virginia",
                "Wisconsin",
                "Wyoming"

            };
            ViewData["States"] = states;

            IList<string> activityLevel = new List<string>()
            {
                "inactive",
                "sedentary",
                "active",
                "extremely active"
            };
            ViewData["ActivityLevels"] = activityLevel;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                surveyDao.AddSurvey(survey);
                return RedirectToAction("SurveyResult");
            }

            return View(survey);
            
        }

        public IActionResult SurveyResult()
        {
            IList<Park> parks = parkDao.GetParks();
            parks.OrderBy(x => x.Surveys.Count);
            return View(parks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
