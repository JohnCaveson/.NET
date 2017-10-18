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
    public class DbStudentRepository : IStudentRepository
    {
        StudentCourseDbContext _db;
        public DbStudentRepository(StudentCourseDbContext db)
        {
            _db = db;
        }
        public Student Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public ICollection<Student> ReadAll()
        {
            return _db.Students.ToList();
        }

        public Student Read(string id)
        {
            return _db.Students.Include(s => s.Grades)
               .FirstOrDefault(s => s.ENumber == id);
        }

        public void RegisterCourse(string id, StudentCourseGrade scg)
        {
            var student = Read(id);
            if (student != null)
            {
                student.Grades.Add(scg);
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

    }
}
