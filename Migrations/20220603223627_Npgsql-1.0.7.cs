using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyToEnter.ASP.Migrations
{
    public partial class Npgsql107 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Person_Login",
                table: "Person",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_Login",
                table: "Person");
        }
    }
}
