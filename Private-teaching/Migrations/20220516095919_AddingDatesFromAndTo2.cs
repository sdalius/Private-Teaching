using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AddingDatesFromAndTo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.DropColumn(
                name: "To",
                schema: "private_teaching_schema",
                table: "listedSubjects");
        }
    }
}
