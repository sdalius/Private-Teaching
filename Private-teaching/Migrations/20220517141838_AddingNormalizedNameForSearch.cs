using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AddingNormalizedNameForSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "private_teaching_schema",
                table: "subjects",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                schema: "private_teaching_schema",
                table: "subjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                schema: "private_teaching_schema",
                table: "subjects");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "private_teaching_schema",
                table: "subjects",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id");
        }
    }
}
