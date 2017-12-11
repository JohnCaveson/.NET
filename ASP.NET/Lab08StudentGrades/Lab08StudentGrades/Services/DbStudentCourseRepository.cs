using Lab08StudentGrades.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab08StudentGrades.Models.Entities;
using Lab08StudentGrades.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Lab08StudentGrades.Services
{
    public class DbStudentCourseRepository : IStudentCourseRepository
    {
        private StudentCourseGradesDbContext _db;

        public DbStudentCourseRepository(StudentCourseGradesDbContext db)
        {
            _db = db;
        }

        public IQueryable<Course> ReadAllCourses()
        {
            return _db.Courses
                .Include(c => c.StudentGrades);
        }

        public IQueryable<StudentCourseGrade> ReadAllStudentGrades()
        {
            return _db.StudentGrades
                .Include(sg => sg.Course)
                .Include(sg => sg.Student);
        }

        public IQueryable<Student> ReadAllStudents()
        {
            return _db.Students
               .Include(s => s.Grades);
        }
    }

}
