using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_QuestionOptionsquestion_opt~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_QuestionOptionsquestion_option_id_QuestionO~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionOptionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionOptionsquestion_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                newName: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_question_id_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" },
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumns: new[] { "question_option_id", "question_id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_question_id_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                newName: "QuestionOptionsquestion_option_id");

            migrationBuilder.AddColumn<int>(
                name: "QuestionOptionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuestionOptionsquestion_option_id_QuestionO~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "QuestionOptionsquestion_option_id", "QuestionOptionsquestion_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_QuestionOptionsquestion_opt~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "QuestionOptionsquestion_option_id", "QuestionOptionsquestion_id" },
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumns: new[] { "question_option_id", "question_id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
