using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08StudentGrades.Models.Entities
{
    public class Student
    {
        [Key]
        [StringLength(9, MinimumLength = 9)]
        public string ENumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<StudentCourseGrade> Grades { get; set; }
    }

}
