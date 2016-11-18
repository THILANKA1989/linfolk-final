using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Migrations
{
    public partial class newUrlField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryLevel",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryUrl",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryUrl",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryLevel",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
