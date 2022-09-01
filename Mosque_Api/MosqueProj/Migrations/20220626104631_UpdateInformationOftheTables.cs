using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class UpdateInformationOftheTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Years_YearsId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "FotherName",
                table: "Students",
                newName: "Father_Name");

            migrationBuilder.RenameColumn(
                name: "YearsId",
                table: "Groups",
                newName: "YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_YearsId",
                table: "Groups",
                newName: "IX_Groups_YearId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "Father_Name",
                table: "Students",
                newName: "FotherName");

            migrationBuilder.RenameColumn(
                name: "YearId",
                table: "Groups",
                newName: "YearsId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_YearId",
                table: "Groups",
                newName: "IX_Groups_YearsId");

            migrationBuilder.AlterColumn<byte>(
                name: "Phone",
                table: "Teachers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Years_YearsId",
                table: "Groups",
                column: "YearsId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
