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
    public class DbStudentCourseRepository : IStudentCourseRepository
    {
        StudentCourseDbContext _db;
        public DbStudentCourseRepository(StudentCourseDbContext db)
        {
            _db = db;
        }

        public ICollection<StudentCourseGrade> ReadAll()
        {
            return _db.StudentGrades
                .Include(scg => scg.Student)
                .Include(scg => scg.Course)
                .ToList();
        }
    }
}
