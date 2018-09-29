using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class UpdateForeginkeyCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Assets_ThumbnailId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ThumbnailId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ThumbnailId",
                table: "Categories",
                column: "ThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Assets_ThumbnailId",
                table: "Categories",
                column: "ThumbnailId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Assets_ThumbnailId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ThumbnailId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ThumbnailId",
                table: "Categories",
                column: "ThumbnailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Assets_ThumbnailId",
                table: "Categories",
                column: "ThumbnailId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
