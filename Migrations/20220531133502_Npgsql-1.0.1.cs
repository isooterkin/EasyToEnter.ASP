using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToEnter.ASP.Migrations
{
    public partial class Npgsql101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingPeriod",
                table: "Variability",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingPeriod",
                table: "Variability");
        }
    }
}
