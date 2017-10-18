using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.Entities
{
    public class Course
    {
        [StringLength(4,MinimumLength =4)]
        public string Code { get; set; }
        [StringLength(4, MinimumLength = 4)]
        public string Number { get; set; }
        [Required]
        [Range(1,6)]
        public int CreditHours { get; set; }
        public ICollection<StudentCourseGrade> StudentGrades { get; set; }
    }
}
