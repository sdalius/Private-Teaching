using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teacher_id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestParticipants_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropIndex(
                name: "IX_TestParticipants_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.AddColumn<int>(
                name: "teacher_id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
