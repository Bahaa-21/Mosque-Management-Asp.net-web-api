using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class SeedDataForStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Full_Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[First_Name] + ' ' + [Father_Name] + ' ' + [Last_Name]");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Min_Old",
                value: (byte)13);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CountOfAbsenceDay", "CountPage", "Father_Name", "First_Name", "GroupId", "Last_Name" },
                values: new object[,]
                {
                    { 1, (byte)12, 2, 23, "أحمد", "عمر", 3, "محمد" },
                    { 2, (byte)20, 1, 20, "", "عبادة", 2, "سمير" },
                    { 3, (byte)13, 0, 50, "عبد العزيز", "سعيد", 1, "قاسم" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Full_Name",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Min_Old",
                value: (byte)10);
        }
    }
}
