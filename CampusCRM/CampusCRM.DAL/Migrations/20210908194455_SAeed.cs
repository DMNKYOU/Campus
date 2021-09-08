using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCRM.DAL.Migrations
{
    public partial class SAeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a7e2273-cee3-4aa3-968d-49dc7e8e1139", "c36fa948-a2ed-4949-bcc8-339ea2000f26", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f95c9a2d-b8c2-45db-be36-96d9db46a2ff", "7fc8bc5c-27c8-49e0-a222-1104990b9c12", "manager", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a7e2273-cee3-4aa3-968d-49dc7e8e1139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f95c9a2d-b8c2-45db-be36-96d9db46a2ff");
        }
    }
}
