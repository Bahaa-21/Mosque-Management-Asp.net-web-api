using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class SeedDataInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name_Subject" },
                values: new object[,]
                {
                    { 1, "قرآن" },
                    { 2, "حديث" },
                    { 3, "فقه" },
                    { 4, "عقيدة" },
                    { 5, "تفسير" },
                    { 6, "سيرة" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "Id", "YearDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Max_Old", "Min_Old", "NameGroup", "YearId" },
                values: new object[] { 1, (byte)15, (byte)10, "أبو بكر الصديق", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Max_Old", "Min_Old", "NameGroup", "YearId" },
                values: new object[] { 2, (byte)22, (byte)20, "الفاروق", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Max_Old", "Min_Old", "NameGroup", "YearId" },
                values: new object[] { 3, (byte)13, (byte)10, "عثمان بن عفان", 2 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CountOfAbsenceDay", "Email", "First_Name", "GroupId", "Last_Name", "Password", "Phone", "SubjectId" },
                values: new object[] { 1, 0, "b.com", "بهاء الدين", 1, "عاتكة", "atk12345", "0951584338", 1 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CountOfAbsenceDay", "Email", "First_Name", "GroupId", "Last_Name", "Password", "Phone", "SubjectId" },
                values: new object[] { 2, 2, "bilal.com", "بلال", 2, "تللو", "bilal123456", "0997185168", 2 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CountOfAbsenceDay", "Email", "First_Name", "GroupId", "Last_Name", "Password", "Phone", "SubjectId" },
                values: new object[] { 3, 3, "ahmad.com", "أحمد", 3, "Samer", "ahmad12345", "0968522506", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
