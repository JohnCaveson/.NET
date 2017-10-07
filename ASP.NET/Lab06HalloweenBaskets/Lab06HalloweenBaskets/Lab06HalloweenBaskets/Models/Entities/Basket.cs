using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Models.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCalories { get; set; }
        public string Color { get; set; }
        public virtual ICollection<Candy> Candies { get; set; }

        public Basket()
        {
            Candies = new List<Candy>();
        }
    }
}
