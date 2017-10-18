using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab07ORM.Services.Interfaces;
using Lab07ORM.Models.ViewModels;
using Lab07ORM.Models.Entities;

namespace Lab07ORM.Controllers
{
    public class RegistrationController : Controller
    {
        IStudentCourseRepository _studentCourses;
        ICourseRepository _courses;
        IStudentRepository _students;

        public RegistrationController(IStudentCourseRepository studentCourses, ICourseRepository courses, IStudentRepository students)
        {
            _studentCourses = studentCourses;
            _courses = courses;
            _students = students;
        }

        public IActionResult Index()
        {
            var model = _studentCourses.ReadAll()
                .Select(sc => new StudentCourseVM
                {
                    ENumber = sc.Student.ENumber,
                    FullName = sc.Student.LastName + ", " + sc.Student.FirstName,
                    FullCourseCode = sc.Course.Code + sc.Course.Number
                });
            return View(model);
        }

        public IActionResult Register()
        {
            var model = _courses.ReadAll()
                .Select(c => new SelectCourseVM
                {
                    CourseId = c.Code + c.Number,
                    CourseName = c.Code + " " + c.Number
                });
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SelectStudent(string courseId)
        {
            var names = _students.ReadAll()
               .Select(s => new StudentNameVM
               {
                   ENumber = s.ENumber,
                   Name = s.LastName + ", " + s.FirstName
               });
            var model = new SelectStudentVM
            {
                CourseId = courseId,
                StudentNames = names
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RegisterStudentCourse(string courseId, string studentId)
        {
            // Split the course id
            var code = courseId.Substring(0, 4);
            var number = courseId.Substring(4, 4);
            var course = _courses.Read(code, number);

            var student = _students.Read(studentId);

            var scg = new StudentCourseGrade { Course = course, Student = student };
            _students.RegisterCourse(studentId, scg);
            return RedirectToAction("Index");
        }


    }
}