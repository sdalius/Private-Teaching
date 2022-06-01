using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class BookingTableAddUserIDColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Students_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Booking");
        }
    }
}
