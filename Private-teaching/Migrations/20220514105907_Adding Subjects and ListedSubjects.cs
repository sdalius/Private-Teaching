using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AddingSubjectsandListedSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Subject_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Subject_Id);
                });

            migrationBuilder.CreateTable(
                name: "ListedSubjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Listed_Subject_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MinTime = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListedSubjects", x => x.Listed_Subject_ID);
                    table.ForeignKey(
                        name: "FK_ListedSubjects_subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "subjects",
                        principalColumn: "Subject_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListedSubjects_Users_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListedSubjects_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ListedSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                column: "Subject_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListedSubjects",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "subjects",
                schema: "private_teaching_schema");
        }
    }
}
