using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AddingConstraintToQuestionnaireToSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireToSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireToSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuestionnaireToSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireToSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id");
        }
    }
}
