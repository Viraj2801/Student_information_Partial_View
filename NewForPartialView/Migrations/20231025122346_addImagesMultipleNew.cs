using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewForPartialView.Migrations
{
    /// <inheritdoc />
    public partial class addImagesMultipleNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Studs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Studs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
