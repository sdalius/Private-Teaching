using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class SubjectsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ListedSubjects_Users_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListedSubjects",
                schema: "private_teaching_schema",
                table: "ListedSubjects");

            migrationBuilder.RenameTable(
                name: "ListedSubjects",
                schema: "private_teaching_schema",
                newName: "listedSubjects",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameIndex(
                name: "IX_ListedSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                newName: "IX_listedSubjects_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ListedSubjects_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                newName: "IX_listedSubjects_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_listedSubjects",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Listed_Subject_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_Users_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_Users_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_listedSubjects",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.RenameTable(
                name: "listedSubjects",
                schema: "private_teaching_schema",
                newName: "ListedSubjects",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameIndex(
                name: "IX_listedSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                newName: "IX_ListedSubjects_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_listedSubjects_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                newName: "IX_ListedSubjects_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListedSubjects",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                column: "Listed_Subject_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListedSubjects_Users_Id",
                schema: "private_teaching_schema",
                table: "ListedSubjects",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
