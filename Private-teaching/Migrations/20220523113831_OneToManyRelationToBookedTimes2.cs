using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropColumn(
                name: "booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "StudentId");

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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropColumn(
                name: "StudentId",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booked_times_id");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booked_times_id",
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
                principalColumn: "Id");
        }
    }
}
