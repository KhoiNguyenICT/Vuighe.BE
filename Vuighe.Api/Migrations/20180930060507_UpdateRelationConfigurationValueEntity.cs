using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuighe.Api.Migrations
{
    public partial class UpdateRelationConfigurationValueEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationValues",
                table: "ConfigurationValues");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ConfigurationValues",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationValues",
                table: "ConfigurationValues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationValues",
                table: "ConfigurationValues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConfigurationValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationValues",
                table: "ConfigurationValues",
                column: "Key");
        }
    }
}
