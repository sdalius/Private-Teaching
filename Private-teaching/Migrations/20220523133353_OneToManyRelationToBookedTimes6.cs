using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PassedTestsOnSubjects",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassedTestsOnSubjects",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                columns: new[] { "Id", "Subject_Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PassedTestsOnSubjects",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassedTestsOnSubjects",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                column: "Id");
        }
    }
}
