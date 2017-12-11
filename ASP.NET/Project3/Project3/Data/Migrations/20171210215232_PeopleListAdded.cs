using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project3.Data.Migrations
{
    public partial class PeopleListAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "GroceryLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroceryListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroceryListId",
                table: "AspNetUsers",
                column: "GroceryListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GroceryLists_GroceryListId",
                table: "AspNetUsers",
                column: "GroceryListId",
                principalTable: "GroceryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroceryLists_GroceryListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroceryListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "GroceryLists");

            migrationBuilder.DropColumn(
                name: "GroceryListId",
                table: "AspNetUsers");
        }
    }
}
