using Lab06HalloweenBaskets.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Models.DbContexts
{
    public class HalloweenBasketsDbContext : DbContext
    {
        public HalloweenBasketsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Candy> Candies { get; set; }
    }
}
