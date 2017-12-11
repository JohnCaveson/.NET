using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab08StudentGrades.Services.Interfaces;

namespace Lab08StudentGrades.Controllers
{
    public class StudentController : Controller
    {
        IStudentCourseRepository _sc;
        public StudentController(IStudentCourseRepository sc)
        {
            _sc = sc;
        }
        public IActionResult FirstNamesContainingA()
        {
            var students = _sc.ReadAllStudents();
            //Extension Method
            //var query = students.Where(s => s.FirstName.Contains("a"));
            //Query Syntax
            var query = from s in students
                        where s.FirstName.Contains("a")
                        select s;
            var model = query.ToList();
            return View(model);
        }

        public IActionResult OrderByLastName()
        {
            var students = _sc.ReadAllStudents();
            var query = from s in students
                        orderby s.LastName
                        select s;
            var model = query.ToList();
            return View(model);
        }
    }
}