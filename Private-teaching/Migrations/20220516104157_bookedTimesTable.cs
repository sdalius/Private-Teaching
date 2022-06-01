using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class bookedTimesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookedTimes",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Listed_Subject_Id = table.Column<int>(type: "integer", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookedTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookedTimes_listedSubjects_Listed_Subject_Id",
                        column: x => x.Listed_Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "listedSubjects",
                        principalColumn: "Listed_Subject_ID");
                    table.ForeignKey(
                        name: "FK_bookedTimes_Users_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookedTimes_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "bookedTimes",
                column: "Listed_Subject_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookedTimes",
                schema: "private_teaching_schema");
        }
    }
}
