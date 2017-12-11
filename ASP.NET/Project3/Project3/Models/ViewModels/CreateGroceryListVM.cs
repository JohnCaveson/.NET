using Project3.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.ViewModels
{
    public class CreateGroceryListVM
    {
        [DisplayName("Grocery List Name")]
        public string GroceryListName { get; set; }

        public GroceryList CreateGroceryList(string ownerId)
        {
            return new GroceryList {OwnerId = ownerId, GroceryListName = GroceryListName };
        }
    }
}
