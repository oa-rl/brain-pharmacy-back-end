using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class Update09292 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement");

            migrationBuilder.AlterColumn<int>(
                name: "SaleInvoiceId",
                table: "inv_product_movement",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement",
                column: "SaleInvoiceId",
                principalTable: "sale_invoice",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement");

            migrationBuilder.AlterColumn<int>(
                name: "SaleInvoiceId",
                table: "inv_product_movement",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_movement_sale_invoice_SaleInvoiceId",
                table: "inv_product_movement",
                column: "SaleInvoiceId",
                principalTable: "sale_invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
