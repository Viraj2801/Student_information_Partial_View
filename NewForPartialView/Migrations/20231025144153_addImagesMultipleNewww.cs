using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewForPartialView.Migrations
{
    /// <inheritdoc />
    public partial class addImagesMultipleNewww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "StudentImage",
                newName: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "StudentImage",
                newName: "ImageUrl");
        }
    }
}
