using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab08StudentGrades.Services.Interfaces;

namespace Lab08StudentGrades.Controllers
{
    public class HomeController : Controller
    {
        IStudentCourseRepository _sc;
        public HomeController(IStudentCourseRepository sc)
        {
            _sc = sc;
        }

        public IActionResult Index()
        {
            return View(_sc.ReadAllStudents());
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

        public IActionResult FirstNamesContainingA()
        {
            var students = _sc.ReadAllStudents();
            //Extension Method
            //var query = students.Where(s => s.FirstName.Contains("a"));
            //Query Syntax
            var query = from s in _sc.ReadAllStudents()
                        where s.FirstName.Contains("a")
                        select s;
            var model = query.ToList();
            return View(model);
        }

    }
}
