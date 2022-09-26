using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddUserToSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "sale_invoice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_UserId",
                table: "sale_invoice",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_core_user_UserId",
                table: "sale_invoice",
                column: "UserId",
                principalTable: "core_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_core_user_UserId",
                table: "sale_invoice");

            migrationBuilder.DropIndex(
                name: "IX_sale_invoice_UserId",
                table: "sale_invoice");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "sale_invoice");
        }
    }
}
