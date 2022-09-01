using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class AlterColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0654f31f-1e32-4edd-a825-6bd6cf945983");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13e89d1a-a70c-495b-a670-dda6fe814c0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c969570f-c3d2-4d53-a7c8-14050e14fda6");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfAbsenceDay",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "837b3751-e3ef-4385-a83a-2a69b0ceccbb", "0c902b2b-cd21-4209-bdf9-2f36e21a37cc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e7ac2f3-a6f6-4377-a1d4-4ca5031b3fcb", "b62903a7-a7fd-487d-8636-5501726018ba", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17ad5e0c-9af0-481a-a6ac-d2e8b84dee71", "35e0a7aa-969f-40a1-8535-0bebb1e53757", "Adminsitrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ad5e0c-9af0-481a-a6ac-d2e8b84dee71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e7ac2f3-a6f6-4377-a1d4-4ca5031b3fcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837b3751-e3ef-4385-a83a-2a69b0ceccbb");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfAbsenceDay",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0654f31f-1e32-4edd-a825-6bd6cf945983", "aa71fbcd-1dbe-4846-b177-6aaa764317f9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13e89d1a-a70c-495b-a670-dda6fe814c0a", "a65dfb3b-3f9d-4f8c-9841-c4d847bf4806", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c969570f-c3d2-4d53-a7c8-14050e14fda6", "d9058ee2-c345-44b4-89bc-2108dadd479a", "Adminsitrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GroupId",
                table: "Teachers",
                column: "GroupId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Groups_GroupId",
                table: "Teachers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
