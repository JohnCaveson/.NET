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
    public class DbRoleRepository : IRoleRepository
    {
        OverseerDbContext _db;
        public DbRoleRepository(OverseerDbContext db)
        {
            _db = db;
        }
        public Role Create(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role;
        }

        public void Delete(int id)
        {
            Role role = _db.Roles.Find(id);
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }
        
        public Role Read(int id)
        {
            return _db.Roles.FirstOrDefault(r => r.Id == id);
        }
        
        public IQueryable<Role> ReadAll()
        {
            return _db.Roles
                .Include(p => p.ProjectRoles);
        }
        
        public void Update(int id, Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AssignProject(int id, ProjectRole pr)
        {
            var role = Read(id);
            if (role != null)
            {
                role.ProjectRoles.Add(pr);
                Update(0, role);
            }
        }
    }
}
