using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models.Entities;
using Project3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Services
{
    public class DbGroceryItemRepository : IGroceryItemRepository
    {
        #region Dependency Injection and ctor
        ApplicationDbContext _db;
        public DbGroceryItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        #region Cruds Ops

        public GroceryItem CreateGroceryItem(GroceryItem gi)
        {
            _db.Add(gi);
            _db.SaveChanges();
            return gi;
        }

        public IEnumerable<GroceryItem> ReadAllGroceryItems()
        {
            return _db.GroceryItems.ToList();
        }

        public GroceryItem ReadGroceryItem(int id)
        {
            return _db.GroceryItems.FirstOrDefault(gi => gi.Id == id);
        }

        public void UpdateGroceryItem(int id, GroceryItem gi)
        {
            _db.Entry(gi).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteGroceryItem(int id)
        {
            var groceryItem = _db.GroceryItems.Find(id);
            _db.GroceryItems.Remove(groceryItem);
            _db.SaveChanges();
        } 
        #endregion

    }
}
