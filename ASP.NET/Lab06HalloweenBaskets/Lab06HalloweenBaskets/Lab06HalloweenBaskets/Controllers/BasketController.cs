using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab06HalloweenBaskets.Services.Interfaces;
using Lab06HalloweenBaskets.Models.ViewModels;

namespace Lab06HalloweenBaskets.Controllers
{
    public class BasketController : Controller
    {
        private IBasketsRepository _baskets;
        public BasketController(IBasketsRepository baskets)
        {
            _baskets = baskets;
        }

        public IActionResult Index()
        {
            return View(_baskets.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBasketVM cbvm)
        {
            if (ModelState.IsValid)
            {
                _baskets.Create(cbvm.CreateBasket());
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}