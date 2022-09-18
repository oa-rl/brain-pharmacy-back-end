using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class ChangeTableNameProductMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationType",
                table: "OperationType");

            migrationBuilder.RenameTable(
                name: "OperationType",
                newName: "inv_operation_type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inv_operation_type",
                table: "inv_operation_type",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inv_operation_type",
                table: "inv_operation_type");

            migrationBuilder.RenameTable(
                name: "inv_operation_type",
                newName: "OperationType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationType",
                table: "OperationType",
                column: "Id");
        }
    }
}
