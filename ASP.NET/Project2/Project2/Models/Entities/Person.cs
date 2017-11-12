using Project2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [Required, MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<ProjectRole> ProjectRoles { get; set; }

    }
}
