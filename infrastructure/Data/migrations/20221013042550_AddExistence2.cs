using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddExistence2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existence",
                table: "inv_product_movement");

            migrationBuilder.AddColumn<int>(
                name: "Existence",
                table: "inv_product_combination",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existence",
                table: "inv_product_combination");

            migrationBuilder.AddColumn<int>(
                name: "Existence",
                table: "inv_product_movement",
                type: "integer",
                nullable: true);
        }
    }
}
