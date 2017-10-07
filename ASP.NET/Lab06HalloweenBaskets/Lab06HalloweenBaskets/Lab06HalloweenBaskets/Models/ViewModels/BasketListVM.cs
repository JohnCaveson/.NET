using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06HalloweenBaskets.Models.ViewModels
{
    public class BasketListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        [DisplayName("Maximum Calories")]
        public int MaxCalories { get; set; }
        [DisplayName("Number of Candies")]
        public int NumCandies { get; set; }
        [DisplayName("Current Calories")]
        public int CurrentCalories { get; set; }

    }
}
