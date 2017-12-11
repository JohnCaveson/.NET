using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab11Quotes.Models.DbContexts;

namespace Lab11Quotes.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    [Migration("20171115180106_InitCommit")]
    partial class InitCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab11Quotes.Models.Entities.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TheQuote");

                    b.Property<string>("WhoSaidIt");

                    b.HasKey("Id");

                    b.ToTable("Quotes");
                });
        }
    }
}
