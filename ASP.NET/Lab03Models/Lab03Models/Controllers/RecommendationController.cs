using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab03Models.Services;
using Lab03Models.Models;

namespace Lab03Models.Controllers
{
    public class RecommendationController : Controller
    {
        private IRecommendationData _recommendations;

        public RecommendationController(IRecommendationData recommendations)
        {
            _recommendations = recommendations;
        }

        public IActionResult Index()
        {
            return View(_recommendations.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recommendation recommendation)
        {
            if (ModelState.IsValid)
            {
                _recommendations.Create(recommendation);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var recommendation = _recommendations.Read(id);
            if(recommendation == null)
            {
                return RedirectToAction("Index");
            }
            return View(recommendation);
        }

        [HttpPost]
        public IActionResult Edit(Recommendation recommendation)
        {
            if (ModelState.IsValid)
            {
                _recommendations.Update(recommendation.Id, recommendation);
                return RedirectToAction("Index");
            }
            return View(recommendation);
        }

        public IActionResult Details(int id)
        {
            var recommendation = _recommendations.Read(id);
            if(recommendation == null)
            {
                return RedirectToAction("Index");
            }
            return View(recommendation);
        }

        public IActionResult Delete(int id)
        {
            var recommendation = _recommendations.Read(id);
            if(recommendation == null)
            {
                return RedirectToAction("Index");
            }
            return View(recommendation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _recommendations.Delete(id);
            return RedirectToAction("Index");
        }
    }

    /*
     * Data Source=cscidbw.etsu.edu;Integrated Security=False;User ID=csci3110User;Password=Csci3110;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
     */
}