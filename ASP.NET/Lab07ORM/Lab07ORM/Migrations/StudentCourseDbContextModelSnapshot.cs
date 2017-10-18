using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab07ORM.Models.DbContexts;

namespace Lab07ORM.Migrations
{
    [DbContext(typeof(StudentCourseDbContext))]
    partial class StudentCourseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab07ORM.Models.Entities.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(4);

                    b.Property<string>("Number")
                        .HasMaxLength(4);

                    b.Property<int>("CreditHours");

                    b.HasKey("Code", "Number");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lab07ORM.Models.Entities.Student", b =>
                {
                    b.Property<string>("ENumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(9);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("ENumber");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Lab07ORM.Models.Entities.StudentCourseGrade", b =>
                {
                    b.Property<string>("StudentENumber")
                        .HasMaxLength(9);

                    b.Property<string>("CourseCode")
                        .HasMaxLength(4);

                    b.Property<string>("CourseNumber")
                        .HasMaxLength(4);

                    b.Property<string>("LetterGrade")
                        .HasMaxLength(2);

                    b.HasKey("StudentENumber", "CourseCode", "CourseNumber");

                    b.HasIndex("CourseCode", "CourseNumber");

                    b.ToTable("StudentGrades");
                });

            modelBuilder.Entity("Lab07ORM.Models.Entities.StudentCourseGrade", b =>
                {
                    b.HasOne("Lab07ORM.Models.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentENumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab07ORM.Models.Entities.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseCode", "CourseNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
