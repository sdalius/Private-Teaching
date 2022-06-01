using Private_teaching.Models.DTO;
using Private_teaching.Models.Entities;

namespace Private_teaching.Services
{
    public interface ISubjectsService
    {
        List<Subjects>? GetAllSubjects();
        Task<Subjects>? GetSubjectAccordingToName(string Subject_Name);
        Task<Subjects?> UpdateSubjectNameAsync(int subject_id, Subjects model);
        Task<Subjects?> DeleteSubjectAccordingToName(string subject_name);
        Task<List<PassedTestsOnSubjects>?> GetSubjectsThatPassedTest(string userId);
        Task<int> AddSubjectToTeacher(string userId, int subject_Id);
    }
}