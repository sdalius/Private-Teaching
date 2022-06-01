using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestParticipants_questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "questionnaire_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestParticipants_QuestionnaireToSubjects_questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "questionnaire_id",
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionnaireToSubjects",
                principalColumn: "questionnaire_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestParticipants_QuestionnaireToSubjects_questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropIndex(
                name: "IX_TestParticipants_questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropColumn(
                name: "questionnaire_id",
                schema: "private_teaching_schema",
                table: "TestParticipants");
        }
    }
}
