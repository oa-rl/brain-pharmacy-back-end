using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddSaleInvoiceDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sale_invoice_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaleInvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ProductCombinationId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PriceWithOutTax = table.Column<double>(type: "double precision", nullable: false),
                    Tax = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_invoice_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sale_invoice_details_inv_product_combination_ProductCombina~",
                        column: x => x.ProductCombinationId,
                        principalTable: "inv_product_combination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sale_invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Authorization = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    SaleInvoiceDetailsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale_invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sale_invoice_core_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "core_customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sale_invoice_sale_invoice_details_SaleInvoiceDetailsId",
                        column: x => x.SaleInvoiceDetailsId,
                        principalTable: "sale_invoice_details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_CustomerId",
                table: "sale_invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_SaleInvoiceDetailsId",
                table: "sale_invoice",
                column: "SaleInvoiceDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_sale_invoice_details_ProductCombinationId",
                table: "sale_invoice_details",
                column: "ProductCombinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale_invoice");

            migrationBuilder.DropTable(
                name: "sale_invoice_details");
        }
    }
}
