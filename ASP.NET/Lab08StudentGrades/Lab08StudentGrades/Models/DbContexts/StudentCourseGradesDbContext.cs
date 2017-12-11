using Lab08StudentGrades.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08StudentGrades.Models.DbContexts
{
    public class StudentCourseGradesDbContext : DbContext
    {
        public StudentCourseGradesDbContext(DbContextOptions options) : base(options)
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

        public void Seed()
        {
            Database.EnsureCreated();

            if (Students.Any()) return;

            var students = new List<Student>
      {
         new Student { ENumber = "E00000001", FirstName = "James", LastName = "Smith" },
         new Student { ENumber = "E00000002", FirstName = "Maria", LastName = "Garcia" },
         new Student { ENumber = "E00000003", FirstName = "Chen", LastName = "Li" },
         new Student { ENumber = "E00000004", FirstName = "Aban", LastName = "Hakim" }
      };

            Students.AddRange(students);
            SaveChanges();

            if (!Courses.Any(c => c.Code == "CSCI" && c.Number == "3110"))
            {
                Courses.Add(
                    new Course { Code = "CSCI", Number = "3110", CreditHours = 3 });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000001", CourseCode = "CSCI", CourseNumber = "3110", LetterGrade = "B+" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000002", CourseCode = "CSCI", CourseNumber = "3110", LetterGrade = "A" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000004", CourseCode = "CSCI", CourseNumber = "3110", LetterGrade = "C+" });
            }

            if (!Courses.Any(c => c.Code == "CSCI" && c.Number == "1250"))
            {
                Courses.Add(
                    new Course { Code = "CSCI", Number = "1250", CreditHours = 4 });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000001", CourseCode = "CSCI", CourseNumber = "1250", LetterGrade = "C" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000002", CourseCode = "CSCI", CourseNumber = "1250", LetterGrade = "D" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000003", CourseCode = "CSCI", CourseNumber = "1250", LetterGrade = "A-" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000004", CourseCode = "CSCI", CourseNumber = "1250", LetterGrade = "A" });
            }

            if (!Courses.Any(c => c.Code == "CSCI" && c.Number == "1260"))
            {
                Courses.Add(
                    new Course { Code = "CSCI", Number = "1260", CreditHours = 4 });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000002", CourseCode = "CSCI", CourseNumber = "1260", LetterGrade = "F" });
                StudentGrades.Add(
                    new StudentCourseGrade
                    { StudentENumber = "E00000004", CourseCode = "CSCI", CourseNumber = "1260", LetterGrade = "A" });
            }

            SaveChanges();
        }
    }

}
