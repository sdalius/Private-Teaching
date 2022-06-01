using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Private_teaching.Helpers;
using Private_teaching.Models.DTO;
using Private_teaching.Models.Entities;

namespace Private_teaching.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly ApplicationDbContext _dbContext;

        public SubjectsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Subjects>? GetAllSubjects()
        {
            List<Subjects>? subjectList = _dbContext.Subjects.ToList();

            if (subjectList != null)
            {
                return subjectList;
            }
            return null;
        }
        public async Task<Subjects>? GetSubjectAccordingToName(string Subject_Name)
        {
            Subjects? subject =  _dbContext.Subjects.Where(e => e.Name == Subject_Name).First();

            return subject;
        }
        public async Task<Subjects> InsertSubjectAsync(string Subject_Name)
        {
            Subjects subject = new Subjects
            {
                Name = Subject_Name,
                NormalizedName = Subject_Name.ToUpper()
            };

            _dbContext.Subjects.Add(subject);

             await _dbContext.SaveChangesAsync();

            return subject;
        }

        public async Task<Subjects?> UpdateSubjectNameAsync(int subject_id, Subjects model)
        {
            Subjects? subject = _dbContext.Subjects.Find(subject_id);

            if (subject != null)
            {
                if (model.Name != null)
                {
                    subject.Name = model.Name;
                }
                await _dbContext.SaveChangesAsync();

                return model;
            }
            return null;
        }
        public async Task<Subjects?> DeleteSubjectAccordingToName(string subject_name)
        {
            var subject = _dbContext.Subjects.SingleOrDefault(e => e.Name == subject_name);

            if (subject != null)
            {
                _dbContext.Subjects.Remove(subject);

                await _dbContext.SaveChangesAsync();

                return subject;
            }
            return null;
        }

        public async Task<List<PassedTestsOnSubjects>?> GetSubjectsThatPassedTest(string userId)
        {
            var results =  await _dbContext.PassedTestsOnSubjects
                .Where(e => e.Id == userId && e.hasPassed == true)
                    .Include(e => e.Subjects)
                .ToListAsync();

            return results;
        }
        public async Task<int> AddSubjectToTeacher(string userId, int subject_Id)
        {
            var subjectRelationExists = _dbContext.PassedTestsOnSubjects
                .Where(e => e.Subject_Id == subject_Id)
                .Where(e => e.Id == userId).FirstOrDefault();

            var nu = 60;

            if (subjectRelationExists != null)
            {
                return 0;
            }

            PassedTestsOnSubjects passedTestsOnSubjects = new PassedTestsOnSubjects
            {
                Id = userId,
                Subject_Id = subject_Id
            };
            await _dbContext.PassedTestsOnSubjects.AddAsync(passedTestsOnSubjects);

            var result = _dbContext.SaveChanges();

            return result;
        }
    }
}
