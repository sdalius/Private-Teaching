using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class PolishingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionOptions_question_id",
                schema: "private_teaching_schema",
                table: "QuestionOptions");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                columns: new[] { "question_id", "question_option_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" },
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumns: new[] { "question_id", "question_option_id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                columns: new[] { "question_option_id", "question_id" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_question_id",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_id_question_option~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" },
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumns: new[] { "question_option_id", "question_id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
