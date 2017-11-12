using Microsoft.AspNetCore.Mvc.Rendering;
using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class CreateProjectRoleVM
    {
        public int PersonId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }

        public ProjectRole CreateProjectRole()
        {
            return new ProjectRole { PersonId = PersonId, ProjectId = ProjectId, RoleId = RoleId };
        }
    }
}
