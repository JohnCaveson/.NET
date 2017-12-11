using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Lab08StudentGrades.Models.DbContexts;

namespace Lab08StudentGrades.Migrations
{
    [DbContext(typeof(StudentCourseGradesDbContext))]
    [Migration("20171025164420_Lab08InitCommit")]
    partial class Lab08InitCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab08StudentGrades.Models.Entities.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(4);

                    b.Property<string>("Number")
                        .HasMaxLength(4);

                    b.Property<int>("CreditHours");

                    b.HasKey("Code", "Number");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lab08StudentGrades.Models.Entities.Student", b =>
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

            modelBuilder.Entity("Lab08StudentGrades.Models.Entities.StudentCourseGrade", b =>
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

            modelBuilder.Entity("Lab08StudentGrades.Models.Entities.StudentCourseGrade", b =>
                {
                    b.HasOne("Lab08StudentGrades.Models.Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentENumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab08StudentGrades.Models.Entities.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseCode", "CourseNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
