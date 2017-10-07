using Lab06HalloweenBaskets.Models.DbContexts;
using Lab06HalloweenBaskets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06HalloweenBaskets.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab06HalloweenBaskets.Services
{
    public class DbBasketsRepository : IBasketsRepository
    {
        private HalloweenBasketsDbContext _db;
        public DbBasketsRepository(HalloweenBasketsDbContext db)
        {
            _db = db;
        }

        public List<Basket> ReadAll()
        {
            return _db.Baskets.Include(b => b.Candies).ToList();
        }

        public Basket Create(Basket basket)
        {
            _db.Baskets.Add(basket);
            _db.SaveChanges();
            return basket;
        }

        public Basket Read(int id)
        {
            return _db.Baskets.Include(b => b.Candies).FirstOrDefault(b => b.Id == id);
        }

        public void Update(int id ,Basket basket)
        {
            _db.Entry(basket).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
