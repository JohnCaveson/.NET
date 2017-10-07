using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab06HalloweenBaskets.Services.Interfaces;
using Lab06HalloweenBaskets.Models.ViewModels;

namespace Lab06HalloweenBaskets.Controllers
{
    public class CandyController : Controller
    {
        private IBasketsRepository _baskets;
        public CandyController(IBasketsRepository baskets)
        {
            _baskets = baskets;
        }
        public IActionResult Index([Bind(Prefix ="id")]int basketId)
        {
            var basket = _baskets.Read(basketId);
            if(basket == null)
            {
                return NotFound();
            }
            return View(basket);
        }

        public IActionResult Create(int basketId)
        {
            var basket = _baskets.Read(basketId);
            if(basket == null)
            {
                return NotFound();
            }
            ViewData["basket"] = basket;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int basketId, CreateCandyVM candyVM)
        {
            var basket = _baskets.Read(basketId);
            if(basket == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var candy = candyVM.CreateCandy();
                basket.Candies.Add(candy);
                _baskets.Update(basketId, basket);
                return RedirectToAction("Index", new { id = basketId });
            }
            return RedirectToAction("Create", new { basketId = basketId });
        }
    }
}