using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab08StudentGrades.Migrations
{
    public partial class Lab08InitCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Number = table.Column<string>(maxLength: 4, nullable: false),
                    CreditHours = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_StudentGrades_Students_StudentENumber",
                        column: x => x.StudentENumber,
                        principalTable: "Students",
                        principalColumn: "ENumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGrades_Courses_CourseCode_CourseNumber",
                        columns: x => new { x.CourseCode, x.CourseNumber },
                        principalTable: "Courses",
                        principalColumns: new[] { "Code", "Number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_CourseCode_CourseNumber",
                table: "StudentGrades",
                columns: new[] { "CourseCode", "CourseNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
