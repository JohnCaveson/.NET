using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> ReadAll();
        Role Create(Role role);
        Role Read(int id);
        void Update(int id, Role role);
        void Delete(int id);
        void AssignProject(int id, ProjectRole pr);
    }
}
