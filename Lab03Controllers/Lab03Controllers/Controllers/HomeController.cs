using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Lab03Controllers.Models;

namespace Lab03Controllers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "CSCI3110 Lab 3 - Controllers";

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

        public IActionResult Arbitrary(string parameters)
        {
            var safeParams = WebUtility.HtmlEncode(parameters);
            string[] urlParams = safeParams.Split('/');
            var data = "";
            foreach (var s in urlParams)
            {
                data += s + "\n";
            }
            return Content(data);
        }

        public IActionResult Bargraph(string parameters)
        {
            var safeParams = WebUtility.HtmlEncode(parameters);
            string[] urlParams = safeParams.Split('/');
            string[] numbers;
            var data = "";
            foreach (var i in urlParams)
            {
                numbers = i.Split('~');
                data += numbers[0] + ": ";
                for (int n = 0; n < Int32.Parse(numbers[1]); n++)
                {
                    data += "#";
                }
                data += "\n";
            }
            return Content(data);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Arbitrary", "Home", new { parameters = "/2/hello" });
        }

        public IActionResult Mypdf()
        {
            return File("GoodmanGreer-002-Lab6.pdf", "application/pdf");
        }

        public IActionResult ModelDemo()
        {
            var model = new Person { Name = "Greer", Age = 22 };
            return View(model);
        }
    }
}