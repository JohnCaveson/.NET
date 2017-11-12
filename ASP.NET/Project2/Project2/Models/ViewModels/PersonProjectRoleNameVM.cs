using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class PersonProjectRoleNameVM
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
