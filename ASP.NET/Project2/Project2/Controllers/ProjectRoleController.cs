using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Models.Entities;
using Project2.Models.ViewModels;
using Project2.Services.Interfaces;

namespace ProjectRole2.Controllers
{
    public class ProjectRoleController : Controller
    {
        #region Dependency Injection
        IProjectRoleRepository _projectRoles;
        IPersonRepository _people;
        IProjectRepository _projects;
        IRoleRepository _roles;

        public ProjectRoleController(IProjectRoleRepository projectRoles, IPersonRepository people, IProjectRepository projects, IRoleRepository roles)
        {
            _projectRoles = projectRoles;
            _people = people;
            _projects = projects;
            _roles = roles;
        } 
        #endregion

        #region Create Action Methods
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProjectRoleVM projectRole)
        {
            if (ModelState.IsValid)
            {
                _projectRoles.Create(projectRole.CreateProjectRole());
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Edit Action Methods
        public IActionResult Edit(int personId, int projectId, int roleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);
            if (projectRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(projectRole);
        }

        [HttpPost]
        public IActionResult Edit(ProjectRole projectRole)
        {
            if (ModelState.IsValid)
            {
                _projectRoles.Update(projectRole.Id, projectRole);
                return RedirectToAction("Index");
            }
            return View(projectRole);
        }
        #endregion

        #region Details Action Method

        public IActionResult Details(int personId, int projectId, int roleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);
            if (projectRole == null)
            {
                return RedirectToAction("Index");
            }
            return View(projectRole);
        }
        #endregion

        #region Add a person and role to a project Action Method
        public IActionResult SelectPersonAndRole([Bind(Prefix = "id")]int projectId)
        {
            var people = _people.ReadAll()
                .Select(p => new PersonNameVM
                {
                    id = p.Id,
                    Name = p.LastName + ", " + p.FirstName + " " + p.MiddleName,
                });

            var roles = _roles.ReadAll()
               .Select(p => new RoleNameVM
               {
                   id = p.Id,
                   RoleName = p.Name
               });

            var model = new SelectAllVM
            {
                ProjectId = projectId,
                Names = people,
                RoleNames = roles
            };
            return View(model);
        }
        #endregion

        #region Add a project and role to a person Action Method
        public IActionResult SelectProjectAndRole([Bind(Prefix = "id")]int personId)
        {
            var projects = _projects.ReadAll()
               .Select(p => new ProjectNameVM
               {
                   id = p.Id,
                   ProjectName = p.Name
               });

            var roles = _roles.ReadAll()
                .Select(p => new RoleNameVM
                {
                    id = p.Id,
                    RoleName = p.Name
                });


            var model = new SelectAllVM
            {
                Id = personId,
                ProjectNames = projects,
                RoleNames = roles
            };
            return View(model);
        }
        #endregion

        #region Used for removing people from projects Action Method
        public IActionResult SelectProject([Bind(Prefix = "id")]int personId, [Bind(Prefix = "projectId")]int projectId, [Bind(Prefix = "roleId")]int roleId)
        {
            var model = new PersonProjectRoleNameVM
            {
                PersonId = personId,
                ProjectId = projectId,
                RoleId = roleId,
                Name = _people.Read(personId).FirstName,
                ProjectName = _projects.Read(projectId).Name,
                RoleName = _roles.Read(roleId).Name
            };
            return View(model);
        }

        #endregion

        #region Creating a completely new Project Role
        public IActionResult SelectPersonProjectAndRole()
        {
            var projects = _projects.ReadAll()
               .Select(p => new ProjectNameVM
               {
                   id = p.Id,
                   ProjectName = p.Name
               });

            var roles = _roles.ReadAll()
                .Select(p => new RoleNameVM
                {
                    id = p.Id,
                    RoleName = p.Name
                });

            var people = _people.ReadAll()
                .Select(p => new PersonNameVM
                {
                    id = p.Id,
                    Name = p.FirstName + " " + p.LastName
                });

            var model = new SelectAllVM
            {
                ProjectNames = projects,
                RoleNames = roles,
                Names = people
            };

            return View(model);
        }
        #endregion

        #region Projects sorted by people Index Action Method
        public IActionResult PersonProjectIndex()
        {
            var people = _people.ReadAll();
            var projectRole = _projectRoles.ReadAll();

            var query = from p in people
                        join pr in projectRole on p.Id equals pr.PersonId into ProjectRoles
                        select new PersonProjectVM
                        {
                            PersonId = p.Id,
                            PersonName = p.LastName + ", " + p.FirstName + " " + p.MiddleName,
                            ProjectsAndRoles = ProjectRoles
                        };
            var model = query.ToList();
            return View(model);
        }
        #endregion

        #region People sorted by project Index Action Method
        public IActionResult ProjectPersonIndex()
        {
            var projects = _projects.ReadAll();
            var projectRole = _projectRoles.ReadAll();

            var query = from p in projects
                        join pr in projectRole on p.Id equals pr.ProjectId into ProjectRoles
                        select new PersonProjectVM
                        {
                            ProjectId = p.Id,
                            ProjectName = p.Name,
                            PeopleAndRoles = ProjectRoles
                        };
            var model = query.ToList();
            return View(model);
        }
        #endregion

        #region Updating the database after creating a new project role
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AssignPersonProject(int projectId, int personId, int roleId)
        {
            var project = _projects.Read(projectId);
            var person = _people.Read(personId);
            var role = _roles.Read(roleId);
            var pr = new ProjectRole { Person = person, Project = project, Role = role };

            if (_projectRoles.Read(personId, projectId, roleId) != null)
            {
                return RedirectToAction("PersonProjectIndex");
            }
            else
            {
                _projectRoles.Create(pr);
                _people.AssignProject(personId, pr);
                return RedirectToAction("PersonProjectIndex");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AssignProjectPerson(int projectId, int personId, int roleId)
        {
            var project = _projects.Read(projectId);
            var person = _people.Read(personId);
            var role = _roles.Read(roleId);
            var pr = new ProjectRole { Person = person, Project = project, Role = role };

            if (_projectRoles.Read(personId, projectId, roleId) != null)
            {
                return RedirectToAction("ProjectPersonIndex");
            }
            else
            {
                _projectRoles.Create(pr);
                _people.AssignProject(personId, pr);
                return RedirectToAction("ProjectPersonIndex");
            }
        }
        #endregion

        #region Update the role of a person on a project
        public IActionResult UpdateRolePerson([Bind(Prefix = "id")]int personId, [Bind(Prefix = "projectId")]int projectId, [Bind(Prefix = "roleId")]int roleId)
        {
            var roles = _roles.ReadAll()
                .Select(p => new RoleNameVM
                {
                    id = p.Id,
                    RoleName = p.Name
                });

            var model = new SelectAllVM
            {
                Id = personId,
                Name = _people.Read(personId).FirstName,
                ProjectName = _projects.Read(projectId).Name,
                ProjectId = projectId,
                RoleId = roleId,
                RoleNames = roles
            };

            return View(model);
        }

        public IActionResult UpdateRoleProject([Bind(Prefix = "id")]int personId, [Bind(Prefix = "projectId")]int projectId, [Bind(Prefix = "roleId")]int roleId)
        {
            var roles = _roles.ReadAll()
                .Select(p => new RoleNameVM
                {
                    id = p.Id,
                    RoleName = p.Name
                });

            var model = new SelectAllVM
            {
                Id = personId,
                Name = _people.Read(personId).FirstName,
                ProjectName = _projects.Read(projectId).Name,
                ProjectId = projectId,
                RoleId = roleId,
                RoleNames = roles
            };

            return View(model);
        }
        #endregion

        #region Update Action Methods for both Project and Person
        public IActionResult UpdateProjectRolePerson(int projectId, int personId, int roleId, int newRoleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);
            if (projectRole == null)
            {
                return RedirectToAction("PersonProjectIndex");
            }
            return View(projectRole);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("UpdateProjectRolePerson")]
        public IActionResult UpdateProjectRoleConfirmedPerson(int projectId, int personId, int roleId, int newRoleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);

            if (_projectRoles.Read(personId, projectId, newRoleId) != null)
            {
                return RedirectToAction("PersonProjectIndex");
            }
            else
            {
                projectRole.RoleId = newRoleId;
                _projectRoles.Update(0, projectRole);
                return RedirectToAction("PersonProjectIndex");
            }
        }

        public IActionResult UpdateProjectRoleProject(int projectId, int personId, int roleId, int newRoleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);
            if (projectRole == null)
            {
                return RedirectToAction("ProjectPersonIndex");
            }
            return View(projectRole);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("UpdateProjectRoleProject")]
        public IActionResult UpdateProjectRoleConfirmedProject(int projectId, int personId, int roleId, int newRoleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);

            if (_projectRoles.Read(personId, projectId, newRoleId) != null)
            {
                return RedirectToAction("ProjectPersonIndex");
            }
            else
            {
                projectRole.RoleId = newRoleId;
                _projectRoles.Update(0, projectRole);
                return RedirectToAction("ProjectPersonIndex");
            }
        } 
        #endregion

        #region Delete Action Methods
        public IActionResult RemoveFromProject(int personId, int projectId, int roleId)
        {
            var projectRole = _projectRoles.Read(personId, projectId, roleId);
            if (projectRole == null)
            {
                return RedirectToAction("PersonProjectIndex");
            }
            return View(projectRole);
        }

        [HttpPost, ActionName("RemoveFromProject")]
        public IActionResult RemoveFromProjectConfirmed(int personId, int projectId, int roleId)
        {
            _projectRoles.Delete(personId, projectId, roleId);
            return RedirectToAction("PersonProjectIndex");
        } 
        #endregion

    }
}