using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddVirtualFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_sale_invoice_details_SaleInvoiceDetailsId",
                table: "sale_invoice");

            migrationBuilder.DropIndex(
                name: "IX_sale_invoice_SaleInvoiceDetailsId",
                table: "sale_invoice");

            migrationBuilder.DropColumn(
                name: "SaleInvoiceDetailsId",
                table: "sale_invoice");

            migrationBuilder.AddColumn<int>(
                name: "SaleInvoiceEntityId",
                table: "sale_invoice_details",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_details_SaleInvoiceEntityId",
                table: "sale_invoice_details",
                column: "SaleInvoiceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_SaleInvoiceEntityId",
                table: "sale_invoice_details",
                column: "SaleInvoiceEntityId",
                principalTable: "sale_invoice",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_SaleInvoiceEntityId",
                table: "sale_invoice_details");

            migrationBuilder.DropIndex(
                name: "IX_sale_invoice_details_SaleInvoiceEntityId",
                table: "sale_invoice_details");

            migrationBuilder.DropColumn(
                name: "SaleInvoiceEntityId",
                table: "sale_invoice_details");

            migrationBuilder.AddColumn<int>(
                name: "SaleInvoiceDetailsId",
                table: "sale_invoice",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_SaleInvoiceDetailsId",
                table: "sale_invoice",
                column: "SaleInvoiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_sale_invoice_details_SaleInvoiceDetailsId",
                table: "sale_invoice",
                column: "SaleInvoiceDetailsId",
                principalTable: "sale_invoice_details",
                principalColumn: "Id");
        }
    }
}
