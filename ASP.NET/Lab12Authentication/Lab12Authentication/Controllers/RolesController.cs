using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab12Authentication.Services.Interfaces;

namespace Lab12Authentication.Controllers
{
    public class RolesController : Controller
    {
        IAuthenticationRepository _roles;
        public RolesController(IAuthenticationRepository roles)
        {
            _roles = roles;
        }
        public IActionResult Index()
        {
            return View(_roles.ReadAllRoles());
        }
    }
}