using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class PersonProjectVM
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        [DisplayName("Full Name")]
        public string PersonName { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public IEnumerable<ProjectRole> ProjectsAndRoles { get; set; }
        public IEnumerable<ProjectRole> PeopleAndRoles { get; set; }
    }
}
