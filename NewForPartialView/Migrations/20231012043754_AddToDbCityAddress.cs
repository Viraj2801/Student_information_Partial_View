using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewForPartialView.Migrations
{
    /// <inheritdoc />
    public partial class AddToDbCityAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Studs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Studs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Studs");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Studs");
        }
    }
}
