using Lab07ORM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.DbContexts
{
    public class StudentCourseDbContext : DbContext
    {
        public StudentCourseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => new { c.Code, c.Number });
            modelBuilder.Entity<StudentCourseGrade>()
                .HasKey(scg => new { scg.StudentENumber, scg.CourseCode, scg.CourseNumber });
        }
    }
}
