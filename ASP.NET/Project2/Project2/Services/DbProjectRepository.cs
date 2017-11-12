using Project2.Models.DbContexts;
using Project2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project2.Services
{
    public class DbProjectRepository : IProjectRepository
    {
        OverseerDbContext _db;
        public DbProjectRepository(OverseerDbContext db)
        {
            _db = db;
        }

        public Project Create(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        public void Delete(int id)
        {
            Project project = _db.Projects.Find(id);
            _db.Projects.Remove(project);
            _db.SaveChanges();
        }

        public Project Read(int id)
        {
            return _db.Projects.Include(p => p.ProjectRoles)
                .FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Project> ReadAll()
        {
            return _db.Projects
                .Include(p => p.ProjectRoles);
        }

        public void Update(int id, Project project)
        {
            _db.Entry(project).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AssignProject(int id, ProjectRole pr)
        {
            var project = Read(id);
            if (project != null)
            {
                project.ProjectRoles.Add(pr);
                Update(0, project);
            }
        }
    }
}
