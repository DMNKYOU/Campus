using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusCRM.DAL.Migrations
{
    public partial class RequardCurseIdInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
