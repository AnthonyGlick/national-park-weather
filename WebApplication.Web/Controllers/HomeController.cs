using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.Extensions;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDao;

        public HomeController(IParkDAO parkDao)
        {
            this.parkDao = parkDao;
        }

        public IActionResult Index()
        {
            IList<Park> parks = this.parkDao.GetParks();
            return this.View(parks);
        }

        public IActionResult Detail(string id)
        {
            ParkDetail park = new ParkDetail()
            {
                Park = this.parkDao.GetPark(id),
                FiveDayForecast = this.parkDao.GetForecast(id)
            };

            if (this.HttpContext.Session.Get<string>("unit") == "C")
            {
                foreach (DailyWeather forecast in park.FiveDayForecast)
                {
                    forecast.LowDisplay = (int)((forecast.Low - 32) / 1.8);
                    forecast.HighDisplay = (int)((forecast.High - 32) / 1.8);
                }
            }

            return this.View(park);
        }

        /// <summary>
        /// Changes display temperature between Farenheit and Centigrade.
        /// </summary>
        /// <param name="id">park id</param>
        /// <param name="unit">unit of measure</param>
        /// <returns>Redirect to update units page</returns>
        public IActionResult ChangeUnit(string id, string unit)
        {
            this.HttpContext.Session.Set("unit", unit);
            return this.RedirectToAction("Detail", "Home", new { id });
        }

        /// <summary>
        /// Takes the user to the survey form view.
        /// </summary>
        /// <returns>Redirect to survey results page if post successful.</returns>
        [HttpGet]
        public IActionResult Survey()
        {
            IList<Park> parks = this.parkDao.GetParks();
            this.ViewData["Parks"] = parks;
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

            this.ViewData["States"] = states;

            IList<string> activityLevel = new List<string>()
            {
                "inactive",
                "sedentary",
                "active",
                "extremely active"
            };

            this.ViewData["ActivityLevels"] = activityLevel;

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(Survey survey)
        {
            if (this.ModelState.IsValid)
            {
                this.parkDao.AddSurvey(survey);
                return this.RedirectToAction("SurveyResult");
            }

            return this.View(survey);
        }

        /// <summary>
        /// Takes the user to the SurveyResults page if they have filled out the survey form correctly.
        /// </summary>
        /// <returns>Results view page or return to previous view.</returns>
        public IActionResult SurveyResult()
        {
            IList<Park> parks = this.parkDao.GetParks();
            IList<ParkDetail> model = new List<ParkDetail>();
            foreach (Park park in parks)
            {
                ParkDetail pd = new ParkDetail()
                {
                    Park = park,
                    Surveys = this.parkDao.GetSurveys(park.ParkCode)
                };

                model.Add(pd);
            }

            var parksInOrder = model.OrderBy(park => park.Surveys.Count).ToList<ParkDetail>();
            parksInOrder.Reverse();
            return this.View(parksInOrder);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
