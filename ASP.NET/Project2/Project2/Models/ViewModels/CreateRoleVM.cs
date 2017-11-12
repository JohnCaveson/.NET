using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class CreateRoleVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Role CreateRole()
        {
            return new Role { Name = Name, Description = Description };
        }
    }
}
