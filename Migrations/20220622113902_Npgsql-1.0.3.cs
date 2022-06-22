using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToEnter.ASP.Migrations
{
    public partial class Npgsql103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dormitory_AddressId_UniversityId",
                table: "Dormitory");

            migrationBuilder.DropIndex(
                name: "IX_Dormitory_Name",
                table: "Dormitory");

            migrationBuilder.CreateIndex(
                name: "IX_Dormitory_AddressId_UniversityId_Name",
                table: "Dormitory",
                columns: new[] { "AddressId", "UniversityId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dormitory_AddressId_UniversityId_Name",
                table: "Dormitory");

            migrationBuilder.CreateIndex(
                name: "IX_Dormitory_AddressId_UniversityId",
                table: "Dormitory",
                columns: new[] { "AddressId", "UniversityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dormitory_Name",
                table: "Dormitory",
                column: "Name",
                unique: true);
        }
    }
}
