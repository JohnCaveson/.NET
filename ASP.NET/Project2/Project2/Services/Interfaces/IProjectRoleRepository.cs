using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services.Interfaces
{
    public interface IProjectRoleRepository
    {
        IQueryable<ProjectRole> ReadAll();
        ProjectRole Create(ProjectRole ProjectRole);
        ProjectRole Read(int personId, int projectId, int roleId);
        void Update(int id, ProjectRole ProjectRole);
        void Delete(int personId, int projectId, int roleId);
    }
}
