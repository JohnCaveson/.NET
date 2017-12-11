using Lab12Authentication.Data;
using Lab12Authentication.Models;
using Lab12Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12Authentication.Services
{
    public class DbAuthenticationRepository : IAuthenticationRepository
    {
        private AuthenticationDbContext _db;
        private UserManager<ApplicationUser> _um;

        public DbAuthenticationRepository(AuthenticationDbContext db, UserManager<ApplicationUser> um)
        {
            _db = db;
            _um = um;
        }

        public bool AssignRole(string username, string rolename)
        {
            var user = ReadAllUsers().FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                var roles = ReadAllRoles();
                // Get the rolenames by joining user.Roles to roles
                var q = from ur in user.Roles
                        join r in roles on ur.RoleId equals r.Id
                        select new
                        {
                            RoleName = r.Name
                        };
                var role = q.FirstOrDefault(o => o.RoleName == rolename);
                if (role == null)
                {
                    _um.AddToRoleAsync(user, rolename).Wait();
                    return true;
                }
            }
            return false;
        }


        public IQueryable<IdentityRole> ReadAllRoles()
        {
            return _db.Roles;
        }

        public IQueryable<ApplicationUser> ReadAllUsers()
        {
            return _db.Users
                .Include(u => u.Roles);
        }


    }
}
