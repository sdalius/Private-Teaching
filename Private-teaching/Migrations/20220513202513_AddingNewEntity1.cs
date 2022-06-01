using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AddingNewEntity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "private_teaching_schema",
                table: "test",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "private_teaching_schema",
                table: "test");
        }
    }
}
