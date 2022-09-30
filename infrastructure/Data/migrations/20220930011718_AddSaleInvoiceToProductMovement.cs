using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddSaleInvoiceToProductMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleInvoiceId",
                table: "inv_product_movement",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_inv_product_movement_SaleInvoiceId",
                table: "inv_product_movement",
                column: "SaleInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement",
                column: "SaleInvoiceId",
                principalTable: "sale_invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_movement_SaleInvoiceId",
                table: "inv_product_movement");

            migrationBuilder.DropColumn(
                name: "SaleInvoiceId",
                table: "inv_product_movement");
        }
    }
}
