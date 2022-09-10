using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class ModificationMedicalHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHouseEntity",
                table: "MedicalHouseEntity");

            migrationBuilder.RenameTable(
                name: "MedicalHouseEntity",
                newName: "inv_medical_house");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inv_medical_house",
                table: "inv_medical_house",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inv_medical_house",
                table: "inv_medical_house");

            migrationBuilder.RenameTable(
                name: "inv_medical_house",
                newName: "MedicalHouseEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHouseEntity",
                table: "MedicalHouseEntity",
                column: "Id");
        }
    }
}
