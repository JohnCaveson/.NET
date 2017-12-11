using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab09RazorJavaScript.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Random random = new Random();
            ViewData["RandomNumber"] = random.Next(0, 100);
            ViewBag.SomeRandomNumber = random.Next(0, 100);
            return View();
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

        public IActionResult RangeInput()
        {
            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        public IActionResult Strings()
        {
            return View();
        }

        public IActionResult MilesPerGallon()
        {
            return View();
        }

        public IActionResult Graphics()
        {
            return View();
        }
    }
}
