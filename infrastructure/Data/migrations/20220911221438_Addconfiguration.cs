using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class Addconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "core_company");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "core_branch");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_CompanyId",
                table: "core_branch",
                newName: "IX_core_branch_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_core_company",
                table: "core_company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_core_branch",
                table: "core_branch",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "inv_sale_for",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inv_sale_for", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inv_product_combination_MedicalHouseId",
                table: "inv_product_combination",
                column: "MedicalHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inv_product_combination_ProductId",
                table: "inv_product_combination",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inv_product_combination_SaleForId",
                table: "inv_product_combination",
                column: "SaleForId");

            migrationBuilder.CreateIndex(
                name: "IX_inv_product_combination_SizeId",
                table: "inv_product_combination",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_core_branch_core_company_CompanyId",
                table: "core_branch",
                column: "CompanyId",
                principalTable: "core_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_combination_inv_medical_house_MedicalHouseId",
                table: "inv_product_combination",
                column: "MedicalHouseId",
                principalTable: "inv_medical_house",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_combination_inv_product_ProductId",
                table: "inv_product_combination",
                column: "ProductId",
                principalTable: "inv_product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_combination_inv_sale_for_SaleForId",
                table: "inv_product_combination",
                column: "SaleForId",
                principalTable: "inv_sale_for",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_combination_inv_size_SizeId",
                table: "inv_product_combination",
                column: "SizeId",
                principalTable: "inv_size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_core_branch_core_company_CompanyId",
                table: "core_branch");

            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_combination_inv_medical_house_MedicalHouseId",
                table: "inv_product_combination");

            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_combination_inv_product_ProductId",
                table: "inv_product_combination");

            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_combination_inv_sale_for_SaleForId",
                table: "inv_product_combination");

            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_combination_inv_size_SizeId",
                table: "inv_product_combination");

            migrationBuilder.DropTable(
                name: "inv_sale_for");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_combination_MedicalHouseId",
                table: "inv_product_combination");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_combination_ProductId",
                table: "inv_product_combination");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_combination_SaleForId",
                table: "inv_product_combination");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_combination_SizeId",
                table: "inv_product_combination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_core_company",
                table: "core_company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_core_branch",
                table: "core_branch");

            migrationBuilder.RenameTable(
                name: "core_company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "core_branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_core_branch_CompanyId",
                table: "Branches",
                newName: "IX_Branches_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
