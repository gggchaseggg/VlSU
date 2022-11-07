using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroservicesStudent.Migrations
{
    public partial class RefactorToMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Students",
                newName: "Score");

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlaceInRanking",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PlaceInRanking",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Students",
                newName: "Rating");
        }
    }
}
