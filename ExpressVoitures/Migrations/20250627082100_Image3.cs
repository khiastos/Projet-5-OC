using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_5.Migrations
{
    /// <inheritdoc />
    public partial class Image3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Car",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Car",
                newName: "ImagePath");
        }
    }
}
