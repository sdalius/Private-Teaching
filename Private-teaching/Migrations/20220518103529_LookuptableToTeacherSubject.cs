using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class LookuptableToTeacherSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject_Id = table.Column<int>(type: "integer", nullable: false),
                    SubjectsSubject_Id = table.Column<int>(type: "integer", nullable: true),
                    TeachersId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_subjects_SubjectsSubject_Id",
                        column: x => x.SubjectsSubject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "subjects",
                        principalColumn: "Subject_Id");
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectsSubject_Id",
                schema: "private_teaching_schema",
                table: "TeacherSubjects",
                column: "SubjectsSubject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeachersId",
                schema: "private_teaching_schema",
                table: "TeacherSubjects",
                column: "TeachersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherSubjects",
                schema: "private_teaching_schema");
        }
    }
}
