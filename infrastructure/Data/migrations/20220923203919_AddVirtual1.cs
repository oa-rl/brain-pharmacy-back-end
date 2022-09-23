using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddVirtual1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_details_SaleInvoiceId",
                table: "sale_invoice_details",
                column: "SaleInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_SaleInvoiceId",
                table: "sale_invoice_details",
                column: "SaleInvoiceId",
                principalTable: "sale_invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sale_invoice_details_sale_invoice_SaleInvoiceId",
                table: "sale_invoice_details");

            migrationBuilder.DropIndex(
                name: "IX_sale_invoice_details_SaleInvoiceId",
                table: "sale_invoice_details");

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
    }
}
