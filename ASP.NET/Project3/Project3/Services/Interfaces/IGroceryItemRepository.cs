using Project3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services.Interfaces
{
    public interface IGroceryItemRepository
    {
        GroceryItem CreateGroceryItem(GroceryItem gi);
        GroceryItem ReadGroceryItem(int id);
        IEnumerable<GroceryItem> ReadAllGroceryItems();
        void UpdateGroceryItem(int id, GroceryItem gi);
        void DeleteGroceryItem(int id);
    }
}
