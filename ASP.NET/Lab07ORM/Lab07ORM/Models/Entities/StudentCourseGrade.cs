using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.Entities
{
    public class StudentCourseGrade
    {
        [StringLength(9,MinimumLength =9)]
        public string StudentENumber { get; set; }
        [StringLength(4,MinimumLength =4)]
        public string CourseCode { get; set; }
        [StringLength(4, MinimumLength = 4)]
        public string CourseNumber { get; set; }
        [StringLength(2)]
        public string LetterGrade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
