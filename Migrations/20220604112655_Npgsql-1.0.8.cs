using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EasyToEnter.ASP.Migrations
{
    public partial class Npgsql108 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FocusUniversityFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FocusUniversityId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FocusUniversityFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FocusUniversityFavorites_FocusUniversity_FocusUniversityId",
                        column: x => x.FocusUniversityId,
                        principalTable: "FocusUniversity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FocusUniversityFavorites_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FocusUniversityFavorites_FocusUniversityId_PersonId",
                table: "FocusUniversityFavorites",
                columns: new[] { "FocusUniversityId", "PersonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FocusUniversityFavorites_PersonId",
                table: "FocusUniversityFavorites",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FocusUniversityFavorites");
        }
    }
}
