using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Project3.Models;
using Project3.Models.ViewModels;
using Project3.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Project3.Controllers
{
    [Authorize]
    public class GroceryListController : Controller
    {
        #region Ctor and Dependency Injection
        IGroceryListRepository _groceryLists;
        IUserRepository _userManager;
        UserManager<ApplicationUser> _manager;
        SignInManager<ApplicationUser> _siManager;
        public GroceryListController(IGroceryListRepository groceryLists, IUserRepository userManager, UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> siManager)
        {
            _groceryLists = groceryLists;
            _userManager = userManager;
            _manager = manager;
            _siManager = siManager;
        } 
        #endregion

        //Check to see IF Ajax
        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


        #region Create Action Methods
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateGroceryListVM cgvm)
        {
            if (ModelState.IsValid)
            {
                //create a new GroceryList passing the creators id into it
                var glist = _groceryLists.CreateGroceryList(cgvm.CreateGroceryList(_manager.GetUserId(HttpContext.User)));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion


        #region Details Action Method
        public IActionResult Details([Bind(Prefix = "id")]int id)
        {
            var groceryList = _groceryLists.ReadGroceryList(id);
            //Get the user's id from the DB
            string userId = _manager.GetUserId(HttpContext.User);
            //get the user from the DB
            ApplicationUser au = _userManager.ReadAll().FirstOrDefault(p => p.Id == userId);

            //Check both ownership rights and if they have permitted to view the list
            if (userId.Equals(groceryList.OwnerId) || groceryList.PriviligedPeople.Contains(au))
            {
                if (groceryList == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(groceryList);
            }
            else
            {
                return Content("You must be a permitted user to view this list.");
            }
        }
        #endregion

        #region Edit Action Methods

        public IActionResult Edit([Bind(Prefix = "id")]int id)
        {

            var groceryList = _groceryLists.ReadGroceryList(id);
            //again get user id
            string userId = _manager.GetUserId(HttpContext.User);
            //get user
            ApplicationUser au = _userManager.ReadAll().FirstOrDefault(p => p.Id == userId);

            //Validate
            if (userId.Equals(groceryList.OwnerId) || groceryList.PriviligedPeople.Contains(au))
            {
                if (groceryList == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(groceryList);
            }
            else
            {
                return Content("You must be a permitted user to view this list.");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(GroceryList groceryList)
        {
            if (ModelState.IsValid)
            {
                _groceryLists.UpdateGroceryList(groceryList.Id, groceryList);
                return RedirectToAction("Index", "Home");
            }
            return View(groceryList);
        }
        #endregion

        #region View Permissions and make changes to permissions if already allowed
        public IActionResult Permissions(int listId)
        {
            var groceryList = _groceryLists.ReadGroceryList(listId);

            //populate list vm
            var model = new UserListVM
            {
                OwnerId = groceryList.OwnerId,
                ListId = listId,
                ListName = groceryList.GroceryListName
            };

            //RETRIEVAL
            string userId = _manager.GetUserId(HttpContext.User);
            ApplicationUser au = _userManager.ReadAll().FirstOrDefault(p => p.Id == userId);

            //VALIDATION
            if (userId.Equals(groceryList.OwnerId) || groceryList.PriviligedPeople.Contains(au))
            {
                foreach (var user in _userManager.ReadAll())
                {
                    model.AllNames.Add(user);
                }

                foreach (var puser in groceryList.PriviligedPeople)
                {
                    model.PriviledgedUsers.Add(puser);
                }

                return View(model);
            }
            else
            {
                return Content("You must be a permitted user to view this list.");
            }

        }

        /// <summary>
        /// Allow a user to view a list
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GrantPermissions(int listId, string personId)
        {
            var glist = _groceryLists.ReadGroceryList(listId);
            ApplicationUser user = _userManager.ReadAll().FirstOrDefault(p => p.Id == personId);
            glist.PriviligedPeople.Add(user);
            _groceryLists.UpdateGroceryList(0, glist);
            return View();
        }

        /// <summary>
        /// Revoke a user's permission to view a list
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RevokePermissions(int listId, string personId)
        {
            var glist = _groceryLists.ReadGroceryList(listId);
            ApplicationUser user = _userManager.ReadAll().FirstOrDefault(p => p.Id == personId);
            glist.PriviligedPeople.Remove(user);
            _groceryLists.UpdateGroceryList(0, glist);
            return View();
        } 
        #endregion
    }
}