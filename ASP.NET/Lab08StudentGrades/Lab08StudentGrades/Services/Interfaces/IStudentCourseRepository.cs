using Lab08StudentGrades.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08StudentGrades.Services.Interfaces
{
    public interface IStudentCourseRepository
    {
        IQueryable<Student> ReadAllStudents();
        IQueryable<StudentCourseGrade> ReadAllStudentGrades();
        IQueryable<Course> ReadAllCourses();
    }
}
