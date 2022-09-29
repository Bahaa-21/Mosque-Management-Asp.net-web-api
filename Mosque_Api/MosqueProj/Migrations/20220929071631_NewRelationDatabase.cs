using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MosqueProj.Migrations
{
    public partial class NewRelationDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "TeacherYear");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1004e9fa-a5b0-49f7-96bf-dd6493687e01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "597647c3-c357-410d-8cea-01dfe1ef3482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb270b4-2f5c-497f-92de-9ecccf31b8ac");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Name_Subject",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CountOfAbsenceDay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Father_Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "YearDate",
                table: "Years",
                newName: "StartCourse");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Teachers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "CountOfAbsenceDay",
                table: "Teachers",
                newName: "AttendanceDays");

            migrationBuilder.RenameColumn(
                name: "CountPage",
                table: "Students",
                newName: "Point");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndCourse",
                table: "Years",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Age",
                table: "Teachers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameSubject",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceDays",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameGroup",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [FatherName] + ' ' + [LastName]");

            migrationBuilder.CreateTable(
                name: "Groups_Teachers",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups_Teachers", x => new { x.TeacherId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25da39e5-9754-41c3-ab8b-6c8ef63f908a", "556c56e5-a368-404a-92bd-191a7ed377b5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb1695fc-4d5d-40f3-ac33-2a8be2671ef4", "eb7d248e-e327-41f4-b4aa-62e86b0f2e3f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "719ecaac-6ee2-4d69-9535-b0fda4a0b6f5", "739d627f-8085-4f49-a50a-672e60140441", "Adminsitrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Teachers_GroupId",
                table: "Groups_Teachers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Groups_Teachers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25da39e5-9754-41c3-ab8b-6c8ef63f908a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "719ecaac-6ee2-4d69-9535-b0fda4a0b6f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb1695fc-4d5d-40f3-ac33-2a8be2671ef4");

            migrationBuilder.DropColumn(
                name: "EndCourse",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "NameSubject",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AttendanceDays",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StartCourse",
                table: "Years",
                newName: "YearDate");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Teachers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "AttendanceDays",
                table: "Teachers",
                newName: "CountOfAbsenceDay");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Students",
                newName: "CountPage");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Subject",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountOfAbsenceDay",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Father_Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NameGroup",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TeacherYear",
                columns: table => new
                {
                    TeachersId = table.Column<int>(type: "int", nullable: false),
                    YearsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherYear", x => new { x.TeachersId, x.YearsId });
                    table.ForeignKey(
                        name: "FK_TeacherYear_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherYear_Years_YearsId",
                        column: x => x.YearsId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "597647c3-c357-410d-8cea-01dfe1ef3482", "f7c5fb06-3419-4cfc-bc2f-550819cd970b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1004e9fa-a5b0-49f7-96bf-dd6493687e01", "91c484b7-78ae-4b69-8584-b4590c887d57", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccb270b4-2f5c-497f-92de-9ecccf31b8ac", "2ad1bb4b-5592-42d6-818c-eaf50cbfebb6", "Adminsitrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherYear_YearsId",
                table: "TeacherYear",
                column: "YearsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Years_YearId",
                table: "Groups",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
