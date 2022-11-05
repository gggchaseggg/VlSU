using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroservicesStudent.Migrations
{
    public partial class AddCourseIdToStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Students");
        }
    }
}
