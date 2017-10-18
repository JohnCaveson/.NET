using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.ViewModels
{
    public class StudentCourseVM
    {
        public string ENumber { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("Full Course Code")]
        public string FullCourseCode { get; set; }
    }
}
