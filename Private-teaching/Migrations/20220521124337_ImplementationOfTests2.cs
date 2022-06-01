using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                columns: new[] { "question_id", "question_option_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestParticipants_Teachers_Id",
                schema: "private_teaching_schema",
                table: "TestParticipants",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
