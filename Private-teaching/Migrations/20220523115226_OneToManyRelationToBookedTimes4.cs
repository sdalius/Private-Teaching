using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_Id");

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Listed_Subject_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumn: "booking_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "From", "To", "Listed_Subject_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumn: "booking_Id");

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
    }
}
