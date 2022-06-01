using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ImplementationOfTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnaireToSubjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    questionnaire_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject_Id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireToSubjects", x => x.questionnaire_id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "subjects",
                        principalColumn: "Subject_Id");
                });

            migrationBuilder.CreateTable(
                name: "TestParticipants",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    teacher_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParticipants", x => x.test_id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    questionnaire_id = table.Column<int>(type: "integer", nullable: false),
                    question = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionnaireToSubjects_questionnaire_id",
                        column: x => x.questionnaire_id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "QuestionnaireToSubjects",
                        principalColumn: "questionnaire_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    question_option_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    option = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.question_option_id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<string>(type: "text", nullable: true),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    question_option_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_QuestionOptions_question_option_id",
                        column: x => x.question_option_id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "QuestionOptions",
                        principalColumn: "question_option_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Questions_question_id",
                        column: x => x.question_id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Teachers_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_Id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_question_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_question_option_id",
                schema: "private_teaching_schema",
                table: "QuestionAnswers",
                column: "question_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireToSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_question_id",
                schema: "private_teaching_schema",
                table: "QuestionOptions",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_questionnaire_id",
                schema: "private_teaching_schema",
                table: "Questions",
                column: "questionnaire_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswers",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "TestParticipants",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "QuestionOptions",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "QuestionnaireToSubjects",
                schema: "private_teaching_schema");
        }
    }
}
