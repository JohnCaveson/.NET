using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class SelectPersonVM
    {
        public int PersonId { get; set; }
        public IEnumerable<PersonNameVM> Names { get; set; }
    }
}
