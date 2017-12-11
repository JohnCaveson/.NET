using Lab12Authentication.Data;
using Lab12Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12Authentication.Services
{
    public class Initializer
    {
        private AuthenticationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public Initializer(
           AuthenticationDbContext context,
           RoleManager<IdentityRole> roleManager,
           UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }

            if (!_context.Roles.Any(r => r.Name == "Teacher"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Teacher" });
            }

            if (!_context.Roles.Any(r => r.Name == "Student"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Student" });
            }

            if (!_context.Users.Any(u => u.UserName == "admin@test.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@test.com",
                    UserName = "admin@test.com"
                };
                await _userManager.CreateAsync(user, "Pass1!");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }

}
