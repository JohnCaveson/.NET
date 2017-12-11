using Project3.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.ViewModels
{
    public class CreateGroceryVM
    {
        public int ListId { get; set; }
        [DisplayName("Grocery Name")]
        public string ItemName { get; set; }
        [DisplayName("Cost of Grocery")]
        public int Amount { get; set; }

        public CreateGroceryVM()
        {

        }
        public CreateGroceryVM(int id)
        {
            ListId = id;
        }

        public GroceryItem CreateGrocery()
        {
            return new GroceryItem { ItemName = ItemName, Amount = Amount };
        }
    }
}
