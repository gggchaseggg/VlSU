using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroserviceCourse.Migrations
{
    public partial class RefactorToMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Departament",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departament",
                table: "Courses");
        }
    }
}
