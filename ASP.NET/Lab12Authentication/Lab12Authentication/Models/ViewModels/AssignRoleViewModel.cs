using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12Authentication.Models.ViewModels
{
    public class AssignRoleViewModel
    {
        public AssignRoleViewModel()
        {
            UserNames = new List<string>();
            RoleNames = new List<string>();
        }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public ICollection<string> UserNames { get; set; }
        public ICollection<string> RoleNames { get; set; }
    }
}
