using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab05Recommendation.Services.Interfaces;

namespace Lab05Recommendation.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepository _people;
        public HomeController(IPersonRepository people)
        {
            _people = people;
        }
        public IActionResult Index()
        {
            return View(_people.ReadAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
