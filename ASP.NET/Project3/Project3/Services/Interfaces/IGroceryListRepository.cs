using Project3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services.Interfaces
{
    public interface IGroceryListRepository
    {
        GroceryList CreateGroceryList(GroceryList gi);
        GroceryList ReadGroceryList(int id);
        IEnumerable<GroceryList> ReadAllGroceryLists();
        void UpdateGroceryList(int id, GroceryList gl);
        void DeleteGroceryList(int id);
    }
}
