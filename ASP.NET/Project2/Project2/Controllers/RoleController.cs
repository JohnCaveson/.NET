using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Models.ViewModels;
using Project2.Services.Interfaces;
using Project2.Models.Entities;

namespace Project2.Controllers
{
    public class RoleController : Controller
    {
        IRoleRepository _roles;
        public RoleController(IRoleRepository roles)
        {
            _roles = roles;
        }

        public IActionResult Index()
        {
            return View(_roles.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateRoleVM role)
        {
            if (ModelState.IsValid)
            {
                _roles.Create(role.CreateRole());
                return RedirectToAction("PersonProjectIndex", "ProjectRole");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var role = _roles.Read(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _roles.Update(role.Id, role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public IActionResult Delete(int id)
        {
            var role = _roles.Read(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _roles.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var role = _roles.Read(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}