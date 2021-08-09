using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCRM.DAL.Migrations
{
    public partial class ChgeFilInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Teachers",
                newName: "Info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Teachers",
                newName: "Bio");
        }
    }
}
