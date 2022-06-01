using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booked_times_id");

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
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropColumn(
                name: "booked_times_id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropColumn(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
