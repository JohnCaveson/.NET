using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.Entities
{
    public class GroceryList
    {
        public int Id { get; set; }
        [Required]
        public string GroceryListName { get; set; }
        public string OwnerId { get; set; }
        public virtual ICollection<ApplicationUser> PriviligedPeople { get; set; }
        public virtual ICollection<GroceryItem> GroceryItems { get; set; }

        public GroceryList()
        {
            GroceryItems = new List<GroceryItem>();
            PriviligedPeople = new List<ApplicationUser>();
        }
    }
}
