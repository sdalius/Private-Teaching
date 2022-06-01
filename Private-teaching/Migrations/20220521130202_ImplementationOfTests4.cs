using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Questions_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Questionsquestion_id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Questions_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Questionsquestion_id",
                principalSchema: "private_teaching_schema",
                principalTable: "Questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
