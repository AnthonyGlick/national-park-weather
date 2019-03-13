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

        public HomeController (IParkDAO parkDao)
        {
            this.parkDao = parkDao;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
