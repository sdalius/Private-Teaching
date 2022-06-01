using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class LookupTableToSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassedTestsOnSubjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Subject_Id = table.Column<int>(type: "integer", nullable: false),
                    hasPassed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedTestsOnSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedTestsOnSubjects_subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "subjects",
                        principalColumn: "Subject_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedTestsOnSubjects_Teachers_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassedTestsOnSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                column: "Subject_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassedTestsOnSubjects",
                schema: "private_teaching_schema");
        }
    }
}
