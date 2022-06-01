using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class OneToManyRelationToBookedTimes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                schema: "private_teaching_schema",
                table: "Booking",
                columns: new[] { "booking_Id", "Listed_Subject_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Listed_Subject_Id" },
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumns: new[] { "booking_Id", "Listed_Subject_Id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "booking_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "booking_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "booking_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumn: "booking_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
