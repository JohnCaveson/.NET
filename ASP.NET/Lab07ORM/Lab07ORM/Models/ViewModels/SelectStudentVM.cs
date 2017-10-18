using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07ORM.Models.ViewModels
{
    public class SelectStudentVM
    {
        public string CourseId { get; set; }
        public IEnumerable<StudentNameVM> StudentNames { get; set; }

    }
}
