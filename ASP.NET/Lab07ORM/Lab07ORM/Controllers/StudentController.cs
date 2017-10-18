using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab07ORM.Services.Interfaces;
using Lab07ORM.Models.ViewModels;

namespace Lab07ORM.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository _students;
        public StudentController(IStudentRepository students)
        {
            _students = students;
        }
        public IActionResult Index()
        {
            return View(_students.ReadAll());
        }
         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentVM student)
        {
            if (ModelState.IsValid)
            {
                _students.Create(student.CreateStudent());
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}