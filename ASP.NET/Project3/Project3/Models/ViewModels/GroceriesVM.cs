using Project3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.ViewModels
{
    public class GroceriesVM
    {
        public int ListId { get; set; }
        public IEnumerable<GroceryItem> Groceries { get; set; }
    }
}
