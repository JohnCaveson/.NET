using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab06HalloweenBaskets.Services.Interfaces;
using Lab06HalloweenBaskets.Models.ViewModels;

namespace Lab06HalloweenBaskets.Controllers
{
    public class HomeController : Controller
    {
        private IBasketsRepository _baskets;
        public HomeController(IBasketsRepository baskets)
        {
            _baskets = baskets;
        }
        public IActionResult Index()
        {
            var model = _baskets.ReadAll()
                .Select(b => new BasketListVM
                {
                    Id = b.Id,
                    Name = b.Name,
                    Color = b.Color,
                    MaxCalories = b.MaxCalories,
                    NumCandies = b.Candies.Count(),
                    CurrentCalories = !b.Candies.Any() ? 0 : b.Candies.Sum(c => c.Calories)
                });
            return View(model);
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
