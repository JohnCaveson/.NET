using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab08StudentGrades.Services.Interfaces;
using Lab08StudentGrades.Models.ViewModels;

namespace Lab08StudentGrades.Controllers
{
    public class GradeController : Controller
    {
        IStudentCourseRepository _repo;
        public GradeController(IStudentCourseRepository repo)
        {
            _repo = repo;
        }

        public IActionResult StudentsWithGradeA()
        {
            var students = _repo.ReadAllStudents();
            ViewData["Title"] = "Students With Grade A";
            /*
             * Query syntax
            var query = from s in students
                        where s.Grades.Any(sg => sg.LetterGrade == "A")
                        select s;
            */
            var query = students.Where(s => s.Grades.Any(sg => sg.LetterGrade == "A"));
            var model = query.ToList();
            return View(model);
        }

        public IActionResult StudentsWithGrade([Bind(Prefix = "id")]string grade)
        {
            var students = _repo.ReadAllStudents();
            ViewData["Title"] = "Students With Grade " + grade;
            var query = students.Where(s => s.Grades.Any(sg => sg.LetterGrade == grade));
            var model = query.ToList();
            return View(model);
        }

        public IActionResult StudentsCoursesWithA()
        {
            ViewData["Title"] = "Students and Courses with A";
            var students = _repo.ReadAllStudents();
            var studentGrades = _repo.ReadAllStudentGrades();
            /*
            var query = students
                .Join(
                    studentGrades,
                    s => s.ENumber,
                    sg => sg.StudentENumber,
                    (s, sg) => new { Student = s, StudentGrade = sg })
                .Where(sc => sc.StudentGrade.LetterGrade == "A")
                .Select(sc => new StudentCourseVM
                {
                    LastName = sc.Student.LastName,
                    CourseCode = sc.StudentGrade.CourseCode,
                    CourseNumber = sc.StudentGrade.CourseNumber
                });
             */
            var query = from s in students
                        join sg in studentGrades on s.ENumber equals sg.StudentENumber
                        where sg.LetterGrade == "A"
                        select new StudentCourseVM
                        {
                            LastName = sg.Student.LastName,
                            CourseCode = sg.CourseCode,
                            CourseNumber = sg.CourseNumber
                        };
            var model = query.ToList();
            return View(model);
        }

        public IActionResult StudentGradesReport()
        {
            var students = _repo.ReadAllStudents();
            var studentGrades = _repo.ReadAllStudentGrades();
            var query = from s in students
                        join sg in studentGrades on s.ENumber equals sg.StudentENumber
                        orderby s.LastName, s.FirstName
                        select new StudentGradesVM
                        {
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            CourseCode = sg.CourseCode,
                            CourseNumber = sg.CourseNumber,
                            LetterGrade = sg.LetterGrade
                        };
            var model = query.ToList();
            return View(model);
        }

        public IActionResult StudentGradesByCourseReport()
        {
            ViewData["Title"] = "Student Grades Report By Course";
            var courses = _repo.ReadAllCourses();
            var studentGrades = _repo.ReadAllStudentGrades();
            /*
            var query = courses
               .GroupJoin(
                  studentGrades,
                  c => new { Code = c.Code, Number = c.Number },
                  sg => new { Code = sg.CourseCode, Number = sg.CourseNumber },
                  (c, grades) => new { Course = c, StudentGrades = grades })
               .Select(csg => new CourseGroupVM
               {
                   CourseCodeNumber = csg.Course.Code + csg.Course.Number,
                   StudentGrades = csg.StudentGrades
               });

            */
            var query = from c in courses
                        join sg in studentGrades 
                            on new {Code = c.Code, Number = c.Number}
                            equals new {Code = sg.CourseCode, Number = sg.CourseNumber} into StudentCourseGrades
                            select new CourseGroupVM
                            {
                                CourseCodeNumber =  c.Code + c.Number,
                                StudentGrades = StudentCourseGrades
                            };
            
            var model = query.ToList();
            return View(model);
        }
    }
}