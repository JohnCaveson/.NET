using Lab07ORM.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.ViewModels
{
    public class CreateCourseVM
    {
        [StringLength(4, MinimumLength = 4)]

        public string Code { get; set; }

        [StringLength(4, MinimumLength = 4)]

        public string Number { get; set; }

        [DisplayName("Credit Hours"), Range(1, 6)]

        public int CreditHours { get; set; }

        public Course CreateCourse()

        {

            return new Course { Code = Code, Number = Number, CreditHours = CreditHours };
        }
    }
}
