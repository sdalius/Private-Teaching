using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class AppliedTBT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_Teachers_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    avgRating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_Teachers_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Students_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_listedSubjects_Teachers_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "private_teaching_schema");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "private_teaching_schema");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Users_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_listedSubjects_Teachers_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
