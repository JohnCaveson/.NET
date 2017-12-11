using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3.Models.ViewModels;
using Project3.Services.Interfaces;
using Project3.Models.Entities;

namespace Project3.Controllers
{
    public class GroceryItemController : Controller
    {
        #region Dependency Injection into ctor
        IGroceryListRepository _groceryLists;
        IGroceryItemRepository _groceryItem;
        public GroceryItemController(IGroceryListRepository groceryLists, IGroceryItemRepository groceryItem)
        {
            _groceryLists = groceryLists;
            _groceryItem = groceryItem;
        } 
        #endregion

        //used internally to see if a request is an Ajax request
        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        #region Create Action Method
        /// <summary>
        /// Create Action Method
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="cgvm"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(int listId, CreateGroceryVM cgvm)
        {
            var list = _groceryLists.ReadGroceryList(listId);
            if (list == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var item = _groceryItem.CreateGroceryItem(cgvm.CreateGrocery());
                list.GroceryItems.Add(item);
                _groceryLists.UpdateGroceryList(0, list);
                if (IsAjaxRequest())
                {
                    return Json(cgvm);
                }
            }
            if (IsAjaxRequest())
            {
                return Json(cgvm);
            }
            return RedirectToAction("Create", "GroceryList", new { listId = listId });
        }
        #endregion

        #region Delete Action Method
        /// <summary>
        /// Delete Action Method
        /// </summary>
        /// <param name="groceryListId"></param>
        /// <param name="groceryItemId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemoveGroceryItem(int groceryListId, int groceryItemId)
        {
            var list = _groceryLists.ReadGroceryList(groceryListId);
            var item = _groceryItem.ReadGroceryItem(groceryItemId);
            _groceryItem.DeleteGroceryItem(groceryItemId);
            list.GroceryItems.Remove(item);
            _groceryLists.UpdateGroceryList(0, list);
            if (IsAjaxRequest())
            {
                return Json("Ok");
            }
            else
            {
                return Json("Not okay");
            }
        } 
        #endregion
    }
}