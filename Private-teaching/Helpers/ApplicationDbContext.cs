using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Private_teaching.Entities.Questionnaire;
using Private_teaching.Models.Entities;

namespace Private_teaching.Helpers
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, IdentityRole, string>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("private_teaching_schema");

            builder.Entity<IdentityRole>().ToTable("Roles", "private_teaching_schema");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "private_teaching_schema");
            builder.Entity<ApplicationUsers>().Ignore(c => c.AccessFailedCount)
                                    .Ignore(c => c.LockoutEnabled)
                                    .Ignore(c => c.EmailConfirmed)
                                    .Ignore(c => c.PhoneNumberConfirmed)
                                    .Ignore(c => c.TwoFactorEnabled)
                                    .Ignore(c => c.LockoutEnd)
                                    .Ignore(c => c.LockoutEnabled)
                                    .Ignore(c => c.AccessFailedCount).ToTable("Users", "private_teaching_schema");
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();


            builder.Entity<BookedTimes>(b =>
            {
                b.ToTable("BookedTimes");
                b.HasKey(x => new { x.booking_Id });
            });

            builder.Entity<Booking>(entity =>
            {
                entity.HasKey(x => new { x.booking_Id, x.Offer_Id });
                entity.Property(e => e.bookingTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired(true);

                entity.Property(e => e.bApproved)
                .HasDefaultValueSql("false");

                entity.Property(e => e.bPayed)
                .HasDefaultValueSql("false");
            });

            builder.Entity<QuestionOptions>(e =>
            {
                e.HasKey(e => new { e.question_id, e.question_option_id });
            });
            builder.Entity<QuestionnaireToSubjects>().HasIndex(u => u.Subject_Id).IsUnique();

            builder.Entity<QuestionOptions>(table =>
            {
                table.HasKey(e => new { e.question_id, e.question_option_id });

                table.HasOne(x => x.Questions)
                .WithMany(x => x.QuestionOptions)
                .HasForeignKey(x => x.question_id);
            });

            builder.Entity<PassedTestsOnSubjects>(entity =>
            {
                entity.Property(e => e.hasPassed)
                .HasDefaultValueSql("false");

                entity.HasKey(e => new { e.Id, e.Subject_Id });
            });
        }

        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Teachers>? Teachers { get; set; }
        public virtual DbSet<Subjects>? Subjects { get; set; }
        public virtual DbSet<Offers>? Offers { get; set; }
        public virtual DbSet<BookedTimes>? BookedTimes { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<QuestionAnswers>? QuestionAnswers { get; set; }
        public virtual DbSet<QuestionnaireToSubjects>? QuestionnaireToSubjects { get; set; }
        public virtual DbSet<QuestionOptions> QuestionOptions { get; set; }
        public virtual DbSet<Questions>? Questions { get; set; }
        public virtual DbSet<TestParticipants>? TestParticipants { get; set; }
        public virtual DbSet<PassedTestsOnSubjects> PassedTestsOnSubjects { get; set; }
    }
}
