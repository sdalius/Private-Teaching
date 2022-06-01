using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Offers_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_booking_Id_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Offer_Id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "Offers",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropIndex(
                name: "IX_BookedTimes_booking_Id_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "private_teaching_schema",
                table: "Offers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTimes",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Offer_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedTimes_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Offer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Offers_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Offer_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Offers",
                principalColumn: "Offer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Teachers_Id",
                schema: "private_teaching_schema",
                table: "Offers",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
