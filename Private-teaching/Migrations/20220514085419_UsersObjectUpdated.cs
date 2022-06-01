using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class UsersObjectUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "private_teaching_schema",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "private_teaching_schema",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "private_teaching_schema",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                schema: "private_teaching_schema",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "private_teaching_schema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "private_teaching_schema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "private_teaching_schema",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                schema: "private_teaching_schema",
                table: "Users");
        }
    }
}
