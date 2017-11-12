using Microsoft.EntityFrameworkCore;
using Project2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.DbContexts
{
    public class OverseerDbContext : DbContext
    {
        public OverseerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }

    }
}
