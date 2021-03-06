﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab11Quotes.Models.DbContexts;

namespace Lab11Quotes.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    partial class QuotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
