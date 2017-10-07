using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMITracker.Services;
using BMITracker.Models.Entities;

namespace BMITracker.Controllers
{
    public class ProfilesController : Controller
    {
        private IBmiData _bmi;

        /// <summary>
        /// ctor with Dependency Injection
        /// </summary>
        /// <param name="bmi"></param>
        public ProfilesController(IBmiData bmi)
        {
            _bmi = bmi;
        }

        /// <summary>
        /// Index action method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_bmi.ReadAll());
        }

        /// <summary>
        /// Create action method
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Create action method
        /// </summary>
        /// <param name="bmi"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(HealthProfile bmi)
        {
            if (ModelState.IsValid)
            {
                _bmi.Create(bmi);
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// Edit action method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var bmi = _bmi.Read(id);
            if (bmi == null)
            {
                return RedirectToAction("Index");
            }
            return View(bmi);
        }

        /// <summary>
        /// Post Edit action method
        /// </summary>
        /// <param name="healthProfile"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(HealthProfile healthProfile)
        {
            if (ModelState.IsValid)
            {
                _bmi.Update(healthProfile.Id, healthProfile);
                return RedirectToAction("Index");
            }
            return View(healthProfile);
        }

        /// <summary>
        /// Delete action method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var bmi = _bmi.Read(id);
            if (bmi == null)
            {
                return RedirectToAction("Index");
            }
            return View(bmi);
        }
        /// <summary>
        /// Delete action method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var bmi = _bmi.Read(id);
            return View(bmi);

        }
        /// <summary>
        /// Post Delete Action Method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _bmi.Delete(Id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Report Action Method
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IActionResult Reports(String type)
        {
            var BmiList = _bmi.ReadAll();
            var Collective = new List<HealthProfile>();
            if(type.ToLower() == "obese" || type.ToLower() == "overweight" || type.ToLower() == "underweight")
            {
                foreach (HealthProfile item in BmiList)
                {
                    if (item.BMI(item.Height, item.Weight).ToLower() == type.ToLower())
                    {
                        Collective.Add(item);
                    }
                }
                return View(Collective);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}