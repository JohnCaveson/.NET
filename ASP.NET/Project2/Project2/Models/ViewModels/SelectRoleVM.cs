using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class SelectRoleVM
    {
        public int ProjectId { get; set; }
        public IEnumerable<RoleNameVM> RoleNames { get; set; }
    }
}
