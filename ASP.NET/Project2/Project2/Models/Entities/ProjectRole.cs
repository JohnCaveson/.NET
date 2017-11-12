using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.Entities
{
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int RoleId { get; set; }

        public Person Person { get; set; }
        public Project Project { get; set; }
        public Role Role { get; set; }
    }
}
