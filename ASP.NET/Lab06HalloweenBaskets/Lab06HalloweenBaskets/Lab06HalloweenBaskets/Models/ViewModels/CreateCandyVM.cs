using Lab06HalloweenBaskets.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Models.ViewModels
{
    public class CreateCandyVM
    {
        public string Name { get; set; }
        public int Calories { get; set; }

        public Candy CreateCandy()
        {
            return new Candy { Name = Name, Calories = Calories };
        }
    }
}
