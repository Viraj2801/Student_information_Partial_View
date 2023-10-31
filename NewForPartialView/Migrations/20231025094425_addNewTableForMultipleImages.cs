using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewForPartialView.Migrations
{
    /// <inheritdoc />
    public partial class addNewTableForMultipleImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Studs");

            migrationBuilder.CreateTable(
                name: "StudentImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentImage_Studs_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentImage_StudentId",
                table: "StudentImage",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Studs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
