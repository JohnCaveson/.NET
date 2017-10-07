using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lab05Recommendation.Models.Entities;

namespace Lab05Recommendation.Models.DbContexts
{
    public partial class RecommendationDbContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Recommendation> Recommendation { get; set; }

        public RecommendationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.Property(e => e.Narrative)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecommenderName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Recommendation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Recommendation_Person");
            });
        }
    }
}