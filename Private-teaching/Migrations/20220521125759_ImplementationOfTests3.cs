using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Questions_question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "QuestionOptionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionOptionsquestion_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                columns: new[] { "question_option_id", "question_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuestionOptionsquestion_option_id_QuestionO~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "QuestionOptionsquestion_option_id", "QuestionOptionsquestion_id" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Questionsquestion_id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_QuestionOptionsquestion_opt~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "QuestionOptionsquestion_option_id", "QuestionOptionsquestion_id" },
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumns: new[] { "question_option_id", "question_id" },
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_QuestionOptionsquestion_opt~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Questions_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_QuestionOptionsquestion_option_id_QuestionO~",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionOptionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionOptionsquestion_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "Questionsquestion_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                column: "question_option_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_option_id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_QuestionOptions_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_option_id",
                principalSchema: "private_teaching_schema",
                principalTable: "QuestionOptions",
                principalColumn: "question_option_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Questions_question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_id",
                principalSchema: "private_teaching_schema",
                principalTable: "Questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
