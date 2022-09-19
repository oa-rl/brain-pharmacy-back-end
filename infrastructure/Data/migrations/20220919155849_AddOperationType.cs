using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddOperationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_inv_product_movement_OperationTypeId",
                table: "inv_product_movement",
                column: "OperationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_inv_product_movement_inv_operation_type_OperationTypeId",
                table: "inv_product_movement",
                column: "OperationTypeId",
                principalTable: "inv_operation_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inv_product_movement_inv_operation_type_OperationTypeId",
                table: "inv_product_movement");

            migrationBuilder.DropIndex(
                name: "IX_inv_product_movement_OperationTypeId",
                table: "inv_product_movement");
        }
    }
}
