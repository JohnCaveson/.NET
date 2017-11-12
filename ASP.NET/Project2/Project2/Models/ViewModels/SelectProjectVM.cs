using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class SelectProjectVM
    {
        public int PersonId { get; set; }
        public IEnumerable<ProjectNameVM> ProjectNames { get; set; }
    }
}
