using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "StudentId",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "StudentId",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
