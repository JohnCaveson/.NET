using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class CreateProjectVM
    {
        public string Name { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public Project CreateProject()
        {
            return new Project { Name = Name, StartDate = StartDate, EndDate = EndDate };
        }
    }
}
