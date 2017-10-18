using Lab07ORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Services.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> ReadAll();
        Student Create(Student student);
        Student Read(string id);
        void RegisterCourse(string id, StudentCourseGrade model);
    }
}
