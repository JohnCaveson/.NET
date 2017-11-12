using Project2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;
using Project2.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Project2.Services
{
    public class DbProjectRoleRepository : IProjectRoleRepository
    {
        OverseerDbContext _db;
        public DbProjectRoleRepository(OverseerDbContext db)
        {
            _db = db;
        }
        public ProjectRole Create(ProjectRole ProjectRole)
        {
            _db.ProjectRoles.Add(ProjectRole);
            _db.SaveChanges();
            return ProjectRole;
        }

        public void Delete(int personId, int projectId, int roleId)
        {
            var index = _db.ProjectRoles.FirstOrDefault(pr => pr.PersonId == personId && pr.ProjectId == projectId && pr.RoleId == roleId).Id;
            var projectRole = _db.ProjectRoles.Find(index);
            _db.Remove(projectRole);
            _db.SaveChanges();
        }

        public ProjectRole Read(int personId, int projectId, int roleId)
        {
            return _db.ProjectRoles.FirstOrDefault(pr => pr.PersonId == personId && pr.ProjectId == projectId && pr.RoleId == roleId);
        }

        public IQueryable<ProjectRole> ReadAll()
        {
            return _db.ProjectRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Project)
                .Include(pr => pr.Role);
        }

        public void Update(int id, ProjectRole projectRole)
        {
            _db.Entry(projectRole).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
