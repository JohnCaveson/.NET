using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<ProjectRole> ProjectRoles { get; set; }

    }
}
