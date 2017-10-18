using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab07ORM.Migrations
{
    public partial class InitStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Number = table.Column<string>(maxLength: 4, nullable: false),
                    CreditHourse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => new { x.Code, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ENumber = table.Column<string>(maxLength: 9, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ENumber);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    StudentENumber = table.Column<string>(maxLength: 9, nullable: false),
                    CourseCode = table.Column<string>(maxLength: 4, nullable: false),
                    CourseNumber = table.Column<string>(maxLength: 4, nullable: false),
                    LetterGrade = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => new { x.StudentENumber, x.CourseCode, x.CourseNumber });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentGrades");
        }
    }
}
