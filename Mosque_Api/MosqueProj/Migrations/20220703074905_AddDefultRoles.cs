using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class AddDefultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { 1, (byte)15, (byte)13, "أبو بكر الصديق", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Max_Old", "Min_Old", "NameGroup", "YearId" },
                values: new object[] { 2, (byte)22, (byte)20, "الفاروق", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Max_Old", "Min_Old", "NameGroup", "YearId" },
                values: new object[] { 3, (byte)13, (byte)10, "عثمان بن عفان", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CountOfAbsenceDay", "CountPage", "Father_Name", "First_Name", "GroupId", "Last_Name" },
                values: new object[,]
                {
                    { 3, (byte)13, 0, 50, "عبد العزيز", "سعيد", 1, "قاسم" },
                    { 2, (byte)20, 1, 20, "", "عبادة", 2, "سمير" },
                    { 1, (byte)12, 2, 23, "أحمد", "عمر", 3, "محمد" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CountOfAbsenceDay", "Email", "First_Name", "GroupId", "Last_Name", "Password", "Phone", "SubjectId" },
                values: new object[,]
                {
                    { 1, 0, "b.com", "بهاء الدين", 1, "عاتكة", "atk12345", "0951584338", 1 },
                    { 2, 2, "bilal.com", "بلال", 2, "تللو", "bilal123456", "0997185168", 2 },
                    { 3, 3, "ahmad.com", "أحمد", 3, "Samer", "ahmad12345", "0968522506", 3 }
                });
        }
    }
}
