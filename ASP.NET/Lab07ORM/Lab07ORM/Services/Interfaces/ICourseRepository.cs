using Lab07ORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Services.Interfaces
{
    public interface ICourseRepository
    {
        ICollection<Course> ReadAll();

        Course Create(Course course);

        Course Read(string code, string number);
    }
}
