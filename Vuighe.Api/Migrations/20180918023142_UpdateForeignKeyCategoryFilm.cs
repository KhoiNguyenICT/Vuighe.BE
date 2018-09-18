using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class UpdateForeignKeyCategoryFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CategoryFilms_Id",
                table: "CategoryFilms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilms_CategoryId",
                table: "CategoryFilms",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms");

            migrationBuilder.DropIndex(
                name: "IX_CategoryFilms_CategoryId",
                table: "CategoryFilms");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CategoryFilms_Id",
                table: "CategoryFilms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryFilms",
                table: "CategoryFilms",
                columns: new[] { "CategoryId", "FilmId" });
        }
    }
}
