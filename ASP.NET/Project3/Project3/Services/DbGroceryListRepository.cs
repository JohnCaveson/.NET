using Project3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3.Models.Entities;
using Project3.Data;
using Microsoft.EntityFrameworkCore;

namespace Project3.Services
{
    public class DbGroceryListRepository : IGroceryListRepository
    {
        #region Ctor and Dependency Injection
        ApplicationDbContext _db;
        public DbGroceryListRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Cruds Ops
        public GroceryList CreateGroceryList(GroceryList gl)
        {
            _db.Add(gl);
            _db.SaveChanges();
            return gl;
        }

        public IEnumerable<GroceryList> ReadAllGroceryLists()
        {
            return _db.GroceryLists
                .Include(gi => gi.GroceryItems)
                .ToList();
        }

        public GroceryList ReadGroceryList(int id)
        {
            return _db.GroceryLists.Include(i => i.GroceryItems).FirstOrDefault(gl => gl.Id == id);
        }

        public void UpdateGroceryList(int id, GroceryList gl)
        {
            _db.Entry(gl).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteGroceryList(int id)
        {
            var groceryList = _db.GroceryLists.Find(id);
            _db.GroceryLists.Remove(groceryList);
            _db.SaveChanges();
        } 
        #endregion

    }
}
