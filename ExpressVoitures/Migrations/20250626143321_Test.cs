using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet_5.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
