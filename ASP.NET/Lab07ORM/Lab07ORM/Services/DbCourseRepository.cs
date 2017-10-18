using Lab07ORM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab07ORM.Models.Entities;
using Lab07ORM.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Lab07ORM.Services
{
    public class DbCourseRepository : ICourseRepository
    {
        StudentCourseDbContext _db;
        public DbCourseRepository (StudentCourseDbContext db)
        {
            _db = db;
        }

        public Course Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }

        public ICollection<Course> ReadAll()
        {
            return _db.Courses.ToList();
        }

        public Course Read(string code, string number)
        {
            return _db.Courses.Include(c => c.StudentGrades)
               .FirstOrDefault(c => c.Code == code && c.Number == number);
        }

    }
}
