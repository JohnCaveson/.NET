using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab07ORM.Migrations
{
    public partial class SecondStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditHourse",
                table: "Courses",
                newName: "CreditHours");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_CourseCode_CourseNumber",
                table: "StudentGrades",
                columns: new[] { "CourseCode", "CourseNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Students_StudentENumber",
                table: "StudentGrades",
                column: "StudentENumber",
                principalTable: "Students",
                principalColumn: "ENumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrades_Courses_CourseCode_CourseNumber",
                table: "StudentGrades",
                columns: new[] { "CourseCode", "CourseNumber" },
                principalTable: "Courses",
                principalColumns: new[] { "Code", "Number" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Students_StudentENumber",
                table: "StudentGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrades_Courses_CourseCode_CourseNumber",
                table: "StudentGrades");

            migrationBuilder.DropIndex(
                name: "IX_StudentGrades_CourseCode_CourseNumber",
                table: "StudentGrades");

            migrationBuilder.RenameColumn(
                name: "CreditHours",
                table: "Courses",
                newName: "CreditHourse");
        }
    }
}
