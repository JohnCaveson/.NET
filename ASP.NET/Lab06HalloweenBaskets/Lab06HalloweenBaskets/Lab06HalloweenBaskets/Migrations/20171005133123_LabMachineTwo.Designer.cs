using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab06HalloweenBaskets.Models.DbContexts;

namespace Lab06HalloweenBaskets.Migrations
{
    [DbContext(typeof(HalloweenBasketsDbContext))]
    [Migration("20171005133123_LabMachineTwo")]
    partial class LabMachineTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab06HalloweenBaskets.Models.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int>("MaxCalories");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Lab06HalloweenBaskets.Models.Entities.Candy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BasketId");

                    b.Property<int>("Calories");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.ToTable("Candies");
                });

            modelBuilder.Entity("Lab06HalloweenBaskets.Models.Entities.Candy", b =>
                {
                    b.HasOne("Lab06HalloweenBaskets.Models.Entities.Basket")
                        .WithMany("Candies")
                        .HasForeignKey("BasketId");
                });
        }
    }
}
