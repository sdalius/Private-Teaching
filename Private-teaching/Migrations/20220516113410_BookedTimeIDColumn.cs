using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class BookedTimeIDColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookedTimes",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Booked_Time_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookedTimes",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Booked_Time_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bookedTimes_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookedTimes",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_bookedTimes_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropColumn(
                name: "Booked_Time_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookedTimes",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
