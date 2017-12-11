using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.Entities
{
    public class GroceryItem
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string ItemName { get; set; }
    }
}
