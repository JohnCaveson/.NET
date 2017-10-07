using Lab06HalloweenBaskets.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Models.ViewModels
{
    public class CreateBasketVM
    {
        public string Name { get; set; }
        public int MaxCalories { get; set; }

        public string Color { get; set; }

        public Basket CreateBasket()
        {
            return new Basket { Name = Name, MaxCalories = MaxCalories, Color = Color };
        }
    }
}
