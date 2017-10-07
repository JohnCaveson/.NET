using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab05Recommendation.Services.Interfaces;
using Lab05Recommendation.Models.Entities;

namespace Lab05Recommendation.Controllers
{
    public class RecommendationController : Controller
    {
        private IPersonRepository _recommendations;
        private Person person;
        
        public RecommendationController(IPersonRepository recommendations)
        {
            _recommendations = recommendations;
        }

        
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    person =_recommendations.Read((int)id);
                    ViewData["Person"] = person;
                    return View();
                }
                catch(Exception e)
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Create(int pId, Recommendation recommendation)
        {
            if (ModelState.IsValid)
            {
                recommendation.Id = 0;
                person = _recommendations.Read(pId);
                person.Recommendation.Add(recommendation);
                _recommendations.Update(person.Id, person);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
    }
}