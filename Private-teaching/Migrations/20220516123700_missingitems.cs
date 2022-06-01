using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class missingitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookedTimes_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookedTimes",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.DropColumn(
                name: "Booked_Time_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes");

            migrationBuilder.RenameTable(
                name: "bookedTimes",
                schema: "private_teaching_schema",
                newName: "BookedTimes",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTimes_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_Listed_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_bookedTimes_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "From", "To", "Listed_Subject_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Listed_Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "listedSubjects",
                principalColumn: "Listed_Subject_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.RenameTable(
                name: "BookedTimes",
                schema: "private_teaching_schema",
                newName: "bookedTimes",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                newName: "IX_bookedTimes_Listed_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                newName: "IX_bookedTimes_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

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

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTimes_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Listed_Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "listedSubjects",
                principalColumn: "Listed_Subject_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_bookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
