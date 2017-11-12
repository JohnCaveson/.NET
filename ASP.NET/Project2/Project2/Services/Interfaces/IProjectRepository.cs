using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services.Interfaces
{
    public interface IProjectRepository
    {
        IQueryable<Project> ReadAll();
        Project Create(Project project);
        Project Read(int id);
        void Update(int id, Project project);
        void Delete(int id);
        void AssignProject(int id, ProjectRole pr);
    }
}
