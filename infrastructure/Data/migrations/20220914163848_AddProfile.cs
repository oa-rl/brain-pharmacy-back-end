using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.migrations
{
    public partial class AddProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_core_user_ProfileEntity_ProfileId",
                table: "core_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileEntity",
                table: "ProfileEntity");

            migrationBuilder.RenameTable(
                name: "ProfileEntity",
                newName: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Profile",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_core_user_Profile_ProfileId",
                table: "core_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "ProfileEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProfileEntity",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileEntity",
                table: "ProfileEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_core_user_ProfileEntity_ProfileId",
                table: "core_user",
                column: "ProfileId",
                principalTable: "ProfileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
