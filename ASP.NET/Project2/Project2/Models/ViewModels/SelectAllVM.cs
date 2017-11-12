using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class SelectAllVM
    {
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public int Id { get; set; }
        public IEnumerable<PersonNameVM> Names { get; set; }
        public int ProjectId { get; set; }
        public IEnumerable<ProjectNameVM> ProjectNames { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<RoleNameVM> RoleNames { get; set; }
    }
}
