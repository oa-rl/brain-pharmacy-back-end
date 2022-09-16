using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_core_user_Profile_ProfileId",
                table: "core_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "core_profile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_core_profile",
                table: "core_profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_core_user_core_profile_ProfileId",
                table: "core_user",
                column: "ProfileId",
                principalTable: "core_profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_core_user_core_profile_ProfileId",
                table: "core_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_core_profile",
                table: "core_profile");

            migrationBuilder.RenameTable(
                name: "core_profile",
                newName: "Profile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_core_user_Profile_ProfileId",
                table: "core_user",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
