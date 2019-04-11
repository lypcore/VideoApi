using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoApi.Migrations
{
    public partial class _2019040701st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Videos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsRecommend",
                table: "Videos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayCount",
                table: "Videos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "IsRecommend",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "PlayCount",
                table: "Videos");
        }
    }
}
