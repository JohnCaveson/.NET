using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Services.Interfaces;
using Project2.Models.ViewModels;
using Project2.Models.Entities;

namespace Project2.Controllers
{
    public class PersonController : Controller
    {
        IPersonRepository _people;
        public PersonController(IPersonRepository people)
        {
            _people = people;
        }

        public IActionResult Index()
        {
            var model = _people.ReadAll();
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonVM person)
        {
            if (ModelState.IsValid)
            {
                _people.Create(person.CreatePerson());
                return RedirectToAction("PersonProjectIndex","ProjectRole");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _people.Read(id);
            if(person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _people.Update(person.Id, person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _people.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _people.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var person = _people.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}