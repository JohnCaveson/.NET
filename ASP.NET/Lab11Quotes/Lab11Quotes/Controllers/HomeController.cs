using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11Quotes.Services.Interfaces;

namespace Lab11Quotes.Controllers
{
    public class HomeController : Controller
    {
        IQuotesRepository _quotes;
        public HomeController(IQuotesRepository quotes)
        {
            _quotes = quotes;
        }
        public IActionResult Index()
        {
            return View(_quotes.ReadAllQuotes());
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
