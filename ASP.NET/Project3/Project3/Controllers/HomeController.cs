using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3.Services.Interfaces;

namespace Project3.Controllers
{
    public class HomeController : Controller
    {
        IGroceryListRepository _groceryLists;
        public HomeController(IGroceryListRepository groceryLists)
        {
            _groceryLists = groceryLists;
        }
        public IActionResult Index()
        {
            return View(_groceryLists.ReadAllGroceryLists());
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
