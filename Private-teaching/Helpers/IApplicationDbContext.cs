using Microsoft.EntityFrameworkCore;
using Private_teaching.Entities.Questionnaire;
using Private_teaching.Models.Entities;

namespace Private_teaching.Helpers
{
    public interface IApplicationDbContext
    {
        DbSet<BookedTimes>? BookedTimes { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Offers>? Offers { get; set; }
        DbSet<PassedTestsOnSubjects> PassedTestsOnSubjects { get; set; }
        DbSet<QuestionAnswers>? QuestionAnswers { get; set; }
        DbSet<QuestionnaireToSubjects>? QuestionnaireToSubjects { get; set; }
        DbSet<QuestionOptions> QuestionOptions { get; set; }
        DbSet<Questions>? Questions { get; set; }
        DbSet<Student>? Students { get; set; }
        DbSet<Subjects>? Subjects { get; set; }
        DbSet<Teachers>? Teachers { get; set; }
        DbSet<TestParticipants>? TestParticipants { get; set; }
    }
}