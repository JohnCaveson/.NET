using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models.ViewModels
{
    public class UserListVM
    {
        public string OwnerId { get; set; }
        public int ListId { get; set; }
        public string ListName { get; set; }
        public ICollection<ApplicationUser> AllNames { get; set; }
        public ICollection<ApplicationUser> PriviledgedUsers { get; set; }
        public UserListVM()
        {
            AllNames = new List<ApplicationUser>();
            PriviledgedUsers = new List<ApplicationUser>();
        }
    }
}
