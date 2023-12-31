﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewForPartialView.Migrations
{
    /// <inheritdoc />
    public partial class addMultipleImagesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Studs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Studs");
        }
    }
}
