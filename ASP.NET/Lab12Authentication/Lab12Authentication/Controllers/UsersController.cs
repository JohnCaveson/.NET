using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab12Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Lab12Authentication.Models.ViewModels;

namespace Lab12Authentication.Controllers
{
    [Authorize(Roles="Admin")]
    public class UsersController : Controller
    {
        private IAuthenticationRepository _users;

        public UsersController(IAuthenticationRepository users)
        {
            _users = users;
        }
        public IActionResult Index()
        {
            return View(_users.ReadAllUsers());
        }

        public IActionResult AssignRole()
        {
            var users = _users.ReadAllUsers();
            var roles = _users.ReadAllRoles();
            var model = new AssignRoleViewModel
            {

            };
            foreach (var user in users)
            {
                model.UserNames.Add(user.UserName);
            }
            foreach (var role in roles)
            {
                model.RoleNames.Add(role.Name);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignRole(string username, string rolename)
        {
            _users.AssignRole(username, rolename);
            return RedirectToAction("Index");
        }
    }
}