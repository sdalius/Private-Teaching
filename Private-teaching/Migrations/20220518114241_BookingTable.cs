using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class BookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    booking_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Listed_Subject_Id = table.Column<int>(type: "integer", nullable: false),
                    bApproved = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    bPayed = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    bookingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.booking_Id);
                    table.ForeignKey(
                        name: "FK_Booking_listedSubjects_Listed_Subject_Id",
                        column: x => x.Listed_Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "listedSubjects",
                        principalColumn: "Listed_Subject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Listed_Subject_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking",
                schema: "private_teaching_schema");
        }
    }
}
