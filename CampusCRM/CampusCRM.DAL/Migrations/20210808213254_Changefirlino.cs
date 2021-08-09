using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCRM.DAL.Migrations
{
    public partial class Changefirlino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "Info", "Name", "Surname" },
                values: new object[] { 10, 48, "Middle+ developer, play tennis and read fiction", "Alisa", "Kolisnekach" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "Info", "Name", "Surname" },
                values: new object[] { 11, 34, "I like cooking or baking and creating new projects in educational sphere", "Vlad", "Losher" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "StartDate", "TeacherId" },
                values: new object[] { 10, "IOS", new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "StartDate", "TeacherId" },
                values: new object[] { 11, "Front-end", new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "GroupId", "Name", "Surname" },
                values: new object[] { 10, 21, 10, "Dmitriy", "Murashka" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "GroupId", "Name", "Surname" },
                values: new object[] { 11, 22, 10, "Tanya", "Petrachko" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
