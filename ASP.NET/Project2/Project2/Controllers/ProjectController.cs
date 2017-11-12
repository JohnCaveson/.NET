using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Services.Interfaces;
using Project2.Models.ViewModels;
using Project2.Models.Entities;

namespace Project2.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepository _projects;
        public ProjectController(IProjectRepository projects)
        {
            _projects = projects;
        }

        public IActionResult Index()
        {
            return View(_projects.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProjectVM project)
        {
            if (ModelState.IsValid)
            {
                _projects.Create(project.CreateProject());
                return RedirectToAction("PersonProjectIndex", "ProjectRole");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var project = _projects.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _projects.Update(project.Id, project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Delete(int id)
        {
            var project = _projects.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _projects.Delete(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var project = _projects.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }
    }
}