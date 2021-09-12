using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCRM.DAL.Migrations
{
    public partial class SeeUdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "GroupId", "Name", "Surname" },
                values: new object[,]
                {
                    { 12, 22, null, "Oksana", "Kiurd" },
                    { 13, 24, null, "Larisa", "Jiop" }
                });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "TopicTitle1");

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "TopicDescription2", "TopicTitle2" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Program", "Title", "TopicId" },
                values: new object[] { 2, "CourseDescription2", "CourseProgram2", "CourseTitle2", 2 });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comment", "CourseId", "StartDate", "Status", "StudentId" },
                values: new object[] { 2, "I want to gain new knowledge!", 1, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), 0, 13 });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comment", "CourseId", "StartDate", "Status", "StudentId" },
                values: new object[] { 1, "I want to learn!", 1, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), 0, 12 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "CourseTitle1");
        }
    }
}
