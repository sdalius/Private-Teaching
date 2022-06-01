﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Private_teaching.Helpers;

#nullable disable

namespace Private_teaching.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220527103507_check")]
    partial class check
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("private_teaching_schema")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", "private_teaching_schema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionAnswers", b =>
                {
                    b.Property<int>("answer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("answer_id"));

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("question_id")
                        .HasColumnType("integer");

                    b.Property<int>("question_option_id")
                        .HasColumnType("integer");

                    b.HasKey("answer_id");

                    b.HasIndex("Id");

                    b.HasIndex("question_id", "question_option_id");

                    b.ToTable("QuestionAnswers", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionnaireToSubjects", b =>
                {
                    b.Property<int>("questionnaire_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("questionnaire_id"));

                    b.Property<int>("Subject_Id")
                        .HasColumnType("integer");

                    b.HasKey("questionnaire_id");

                    b.HasIndex("Subject_Id")
                        .IsUnique();

                    b.ToTable("QuestionnaireToSubjects", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionOptions", b =>
                {
                    b.Property<int>("question_id")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<int>("question_option_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("question_option_id"));

                    b.Property<string>("option")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("question_id", "question_option_id");

                    b.ToTable("QuestionOptions", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.Questions", b =>
                {
                    b.Property<int>("question_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("question_id"));

                    b.Property<string>("question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("questionnaire_id")
                        .HasColumnType("integer");

                    b.HasKey("question_id");

                    b.HasIndex("questionnaire_id");

                    b.ToTable("Questions", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.TestParticipants", b =>
                {
                    b.Property<int>("test_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("test_id"));

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("questionnaire_id")
                        .HasColumnType("integer");

                    b.HasKey("test_id");

                    b.HasIndex("Id");

                    b.HasIndex("questionnaire_id");

                    b.ToTable("TestParticipants", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.ApplicationUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.BookedTimes", b =>
                {
                    b.Property<int>("booking_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Offer_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("booking_Id");

                    b.HasIndex("Id");

                    b.HasIndex("booking_Id", "Offer_Id")
                        .IsUnique();

                    b.ToTable("BookedTimes", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Booking", b =>
                {
                    b.Property<int>("booking_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("booking_Id"));

                    b.Property<int>("Offer_Id")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("bApproved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.Property<bool?>("bPayed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.Property<DateTime?>("bookingTime")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("booking_Id", "Offer_Id");

                    b.HasIndex("Id");

                    b.HasIndex("Offer_Id");

                    b.ToTable("Booking", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Offers", b =>
                {
                    b.Property<int>("Offer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Offer_Id"));

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("MinTime")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Subject_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Offer_Id");

                    b.HasIndex("Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("Offers", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.PassedTestsOnSubjects", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<int>("Subject_Id")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<bool?>("hasPassed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.HasKey("Id", "Subject_Id");

                    b.HasIndex("Subject_Id");

                    b.ToTable("PassedTestsOnSubjects", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Subjects", b =>
                {
                    b.Property<int>("Subject_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Subject_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Subject_Id");

                    b.ToTable("Subjects", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Student", b =>
                {
                    b.HasBaseType("Private_teaching.Models.Entities.ApplicationUsers");

                    b.ToTable("Students", "private_teaching_schema");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Teachers", b =>
                {
                    b.HasBaseType("Private_teaching.Models.Entities.ApplicationUsers");

                    b.Property<double>("avgRating")
                        .HasColumnType("double precision");

                    b.ToTable("Teachers", "private_teaching_schema");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Models.Entities.ApplicationUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionAnswers", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Teachers", "Teachers")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Entities.Questionnaire.QuestionOptions", "QuestionOptions")
                        .WithMany()
                        .HasForeignKey("question_id", "question_option_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionOptions");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionnaireToSubjects", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Subjects", "Subjects")
                        .WithMany()
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.QuestionOptions", b =>
                {
                    b.HasOne("Private_teaching.Entities.Questionnaire.Questions", "Questions")
                        .WithMany("QuestionOptions")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.Questions", b =>
                {
                    b.HasOne("Private_teaching.Entities.Questionnaire.QuestionnaireToSubjects", "QuestionnaireToSubjects")
                        .WithMany()
                        .HasForeignKey("questionnaire_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionnaireToSubjects");
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.TestParticipants", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Teachers", "Teachers")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Entities.Questionnaire.QuestionnaireToSubjects", "QuestionnaireToSubjects")
                        .WithMany()
                        .HasForeignKey("questionnaire_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionnaireToSubjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.BookedTimes", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Models.Entities.Booking", "Booking")
                        .WithOne("BookedTimes")
                        .HasForeignKey("Private_teaching.Models.Entities.BookedTimes", "booking_Id", "Offer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Booking", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Models.Entities.Offers", "Offers")
                        .WithMany("Bookings")
                        .HasForeignKey("Offer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offers");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Offers", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Teachers", "Teachers")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Models.Entities.Subjects", "Subjects")
                        .WithMany()
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.PassedTestsOnSubjects", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.Teachers", "Teachers")
                        .WithMany("PassedTestsOnSubjects")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Private_teaching.Models.Entities.Subjects", "Subjects")
                        .WithMany()
                        .HasForeignKey("Subject_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Student", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.ApplicationUsers", null)
                        .WithOne()
                        .HasForeignKey("Private_teaching.Models.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Teachers", b =>
                {
                    b.HasOne("Private_teaching.Models.Entities.ApplicationUsers", null)
                        .WithOne()
                        .HasForeignKey("Private_teaching.Models.Entities.Teachers", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Private_teaching.Entities.Questionnaire.Questions", b =>
                {
                    b.Navigation("QuestionOptions");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Booking", b =>
                {
                    b.Navigation("BookedTimes")
                        .IsRequired();
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Offers", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Private_teaching.Models.Entities.Teachers", b =>
                {
                    b.Navigation("PassedTestsOnSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
