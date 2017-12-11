using Lab12Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12Authentication.Services.Interfaces
{
    public interface IAuthenticationRepository
    {
        IQueryable<IdentityRole> ReadAllRoles();
        IQueryable<ApplicationUser> ReadAllUsers();
        bool AssignRole(string username, string rolename);
    }
}
