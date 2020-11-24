using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotcheckr.API.Migrations
{
    public partial class addschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IssuerId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IssuerId",
                table: "Certificates",
                column: "IssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Organizations_IssuerId",
                table: "Certificates",
                column: "IssuerId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Organizations_IssuerId",
                table: "Certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_IssuerId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Certificates");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Organizations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Abbreviation");
        }
    }
}
