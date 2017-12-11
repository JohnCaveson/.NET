using Lab08StudentGrades.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08StudentGrades.Models.ViewModels
{
    public class CourseGroupVM
    {
        public string CourseCodeNumber { get; set; }
        public IEnumerable<StudentCourseGrade> StudentGrades { get; set; }
    }

}
