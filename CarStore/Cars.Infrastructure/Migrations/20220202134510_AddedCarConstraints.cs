using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Infrastructure.Migrations
{
    public partial class AddedCarConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Cars",
                newSchema: "cars");

            migrationBuilder.CreateIndex(
                name: "vin_idx",
                schema: "cars",
                table: "Cars",
                column: "Vin",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "vin_idx",
                schema: "cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                schema: "cars",
                newName: "Cars");
        }
    }
}
