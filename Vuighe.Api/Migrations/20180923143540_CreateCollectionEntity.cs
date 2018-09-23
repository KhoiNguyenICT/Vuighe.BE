using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class CreateCollectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CollectionId",
                table: "Assets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CollectionId",
                table: "Assets",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_FileName",
                table: "Assets",
                column: "FileName");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Collections_CollectionId",
                table: "Assets",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Collections_CollectionId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Assets_CollectionId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_FileName",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Assets");
        }
    }
}
