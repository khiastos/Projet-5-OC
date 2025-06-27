using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_5.Migrations
{
    /// <inheritdoc />
    public partial class Image2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarImage_CarImageId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_CarImageId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CarImageId",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "CarImageId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarImageId",
                table: "Car",
                column: "CarImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarImage_CarImageId",
                table: "Car",
                column: "CarImageId",
                principalTable: "CarImage",
                principalColumn: "Id");
        }
    }
}
