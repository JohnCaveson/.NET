using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab05Recommendation.Services.Interfaces;
using Lab05Recommendation.Models.Entities;

namespace Lab05Recommendation.Controllers
{
    public class PersonController : Controller
    {
        IPersonRepository _people;
        public PersonController(IPersonRepository people)
        {
            _people = people;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if(ModelState.IsValid)
            {
                _people.Create(person);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _people.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if(ModelState.IsValid)
            {
                _people.Update(person.Id, person);
                return RedirectToAction("Index","Home");
            }
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _people.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _people.Delete(Id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var person = _people.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }
    }
}