using Lab07ORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.ViewModels
{
    public class CreateStudentVM
    {
        [StringLength(9, MinimumLength = 9)]
        public string ENumber { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        public Student CreateStudent()

        {
            return new Student { ENumber = ENumber, FirstName = FirstName, LastName = LastName };
        }
    }
}
