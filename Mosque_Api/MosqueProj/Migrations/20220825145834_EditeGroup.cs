using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class EditeGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69cdca27-670c-4677-a9da-06fa89e88140");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ba57169-99aa-4495-ab03-5f0fd2f51b97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f30c83dc-2715-4097-8361-eba5c82d0900");

            migrationBuilder.AlterColumn<short>(
                name: "Min_Old",
                table: "Groups",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<short>(
                name: "Max_Old",
                table: "Groups",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<byte>(
                name: "Min_Old",
                table: "Groups",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<byte>(
                name: "Max_Old",
                table: "Groups",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ba57169-99aa-4495-ab03-5f0fd2f51b97", "a31fa4ca-1eda-46bd-bcae-2ff403f5682d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f30c83dc-2715-4097-8361-eba5c82d0900", "aeb5c4ac-f810-41d4-8f2a-664fe220e36c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69cdca27-670c-4677-a9da-06fa89e88140", "c7c5262e-4c3e-451b-b6cf-e186ef2fde6f", "Adminsitrator", "ADMINISTRATOR" });
        }
    }
}
