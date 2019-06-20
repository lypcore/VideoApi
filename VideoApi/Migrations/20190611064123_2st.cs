using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoApi.Migrations
{
    public partial class _2st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "AnalysisUrls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlayCount",
                table: "AnalysisUrls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "AnalysisUrls");

            migrationBuilder.DropColumn(
                name: "PlayCount",
                table: "AnalysisUrls");
        }
    }
}
