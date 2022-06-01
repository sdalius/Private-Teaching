using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Private_teaching.Migrations
{
    public partial class ListedSubjectsToOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedTestsOnSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.DropTable(
                name: "listedSubjects",
                schema: "private_teaching_schema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjects",
                schema: "private_teaching_schema",
                table: "subjects");

            migrationBuilder.RenameTable(
                name: "subjects",
                schema: "private_teaching_schema",
                newName: "Subjects",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameColumn(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                newName: "Offer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                newName: "IX_Booking_Offer_Id");

            migrationBuilder.RenameColumn(
                name: "Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "Offer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_Offer_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                schema: "private_teaching_schema",
                table: "Subjects",
                column: "Subject_Id");

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject_Id = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MinTime = table.Column<decimal>(type: "numeric", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Offer_Id);
                    table.ForeignKey(
                        name: "FK_Offers_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Subjects",
                        principalColumn: "Subject_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Teachers_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Id",
                schema: "private_teaching_schema",
                table: "Offers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Subject_Id",
                schema: "private_teaching_schema",
                table: "Offers",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Offer_Id" },
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumns: new[] { "booking_Id", "Offer_Id" },
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Booking_Offers_Offer_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Offer_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Offers",
                principalColumn: "Offer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedTestsOnSubjects_Subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireToSubjects_Subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "Subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedTimes_Offers_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Offers_Offer_Id",
                schema: "private_teaching_schema",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_PassedTestsOnSubjects_Subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireToSubjects_Subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects");

            migrationBuilder.DropTable(
                name: "Offers",
                schema: "private_teaching_schema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                schema: "private_teaching_schema",
                table: "Subjects");

            migrationBuilder.RenameTable(
                name: "Subjects",
                schema: "private_teaching_schema",
                newName: "subjects",
                newSchema: "private_teaching_schema");

            migrationBuilder.RenameColumn(
                name: "Offer_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                newName: "Listed_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_Offer_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                newName: "IX_Booking_Listed_Subject_Id");

            migrationBuilder.RenameColumn(
                name: "Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "Listed_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BookedTimes_Offer_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                newName: "IX_BookedTimes_Listed_Subject_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjects",
                schema: "private_teaching_schema",
                table: "subjects",
                column: "Subject_Id");

            migrationBuilder.CreateTable(
                name: "listedSubjects",
                schema: "private_teaching_schema",
                columns: table => new
                {
                    Listed_Subject_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Subject_Id = table.Column<int>(type: "integer", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinTime = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listedSubjects", x => x.Listed_Subject_ID);
                    table.ForeignKey(
                        name: "FK_listedSubjects_subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "subjects",
                        principalColumn: "Subject_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_listedSubjects_Teachers_Id",
                        column: x => x.Id,
                        principalSchema: "private_teaching_schema",
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_listedSubjects_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_listedSubjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "listedSubjects",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTimes_Booking_booking_Id_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "BookedTimes",
                columns: new[] { "booking_Id", "Listed_Subject_Id" },
                principalSchema: "private_teaching_schema",
                principalTable: "Booking",
                principalColumns: new[] { "booking_Id", "Listed_Subject_Id" },
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Booking_listedSubjects_Listed_Subject_Id",
                schema: "private_teaching_schema",
                table: "Booking",
                column: "Listed_Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "listedSubjects",
                principalColumn: "Listed_Subject_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassedTestsOnSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "PassedTestsOnSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireToSubjects_subjects_Subject_Id",
                schema: "private_teaching_schema",
                table: "QuestionnaireToSubjects",
                column: "Subject_Id",
                principalSchema: "private_teaching_schema",
                principalTable: "subjects",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
