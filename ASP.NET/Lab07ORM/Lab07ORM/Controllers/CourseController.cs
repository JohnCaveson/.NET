using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab07ORM.Services.Interfaces;
using Lab07ORM.Models.Entities;
using Lab07ORM.Models.ViewModels;

namespace Lab07ORM.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository _courses;
        public CourseController(ICourseRepository courses)
        {
            _courses = courses;
        }

        public IActionResult Index()
        {
            return View(_courses.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseVM course)
        {
            if (ModelState.IsValid)
            {
                _courses.Create(course.CreateCourse());
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}