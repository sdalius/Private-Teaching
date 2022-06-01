using AutoFixture;
using Moq;
using Moq.EntityFrameworkCore;
using Private_teaching.Helpers;
using Private_teaching.Models.Entities;
using Private_teaching.Services;

namespace PrivateTeachingTesting
{
    public class SubjectsTest
    {
        private static readonly Fixture fixture = new Fixture();

        [Fact]
        public async Task GetSubjectsFromName_Test()
        {
            // Arrange
            IList<Subjects> subjects = GenerateSubjects();

            var userContextMock = new Mock<ApplicationDbContext>();
            userContextMock.Setup(x => x.Subjects).ReturnsDbSet(subjects);

            ISubjectsService? listSubjectsService = new SubjectsService(userContextMock.Object);

            //Act
            var result = await listSubjectsService.GetSubjectAccordingToName("Math");

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InsertSubjectAndFindInDatabase_Test()
        {
            // Arrange
            IList<Subjects> subjects = GenerateSubjects();
            var insertSubject = fixture.Build<Subjects>().With(u => u.Name, "TestPurpose").Create();
            subjects.Add(insertSubject);

            var userContextMock = new Mock<ApplicationDbContext>();
            userContextMock.Setup(x => x.Subjects).ReturnsDbSet(subjects);

            ISubjectsService? listSubjectsService = new SubjectsService(userContextMock.Object);

            var result = await listSubjectsService.GetSubjectAccordingToName("TestPurpose");

            Assert.Equal(insertSubject, result);
        }

        [Fact]
        public async Task UpdateSubjectName_Test()
        {
            // Arrange
            IList<Subjects> subjects = GenerateSubjects();
            var insertSubject = fixture.Build<Subjects>().With(u => u.Subject_Id, 6).Create();
            subjects.Add(insertSubject);

            var userContextMock = new Mock<ApplicationDbContext>();
            userContextMock.Setup(x => x.Subjects).ReturnsDbSet(subjects);

            ISubjectsService? listSubjectsService = new SubjectsService(userContextMock.Object);

            var updateItem = await listSubjectsService.UpdateSubjectNameAsync(6, new Subjects { Name = "Teach" });

            Assert.NotEqual(insertSubject, updateItem);
        }

        [Fact]
        public async Task GetNumberOfSubjects_Test()
        {
            // Arrange
            IList<Subjects> subjects = GenerateSubjects();

            var userContextMock = new Mock<ApplicationDbContext>();
            userContextMock.Setup(x => x.Subjects).ReturnsDbSet(subjects);

            ISubjectsService? listSubjectsService = new SubjectsService(userContextMock.Object);

            var getAllSubjects = listSubjectsService.GetAllSubjects();

            Assert.Equal(3, getAllSubjects.Count);
        }

        [Fact]
        public async Task DeleteSubjectAccordingToName_Test()
        {
            // Arrange
            IList<Subjects> subjects = GenerateSubjects();

            var userContextMock = new Mock<ApplicationDbContext>();
            userContextMock.Setup(x => x.Subjects).ReturnsDbSet(subjects);
            // Mock the insertion of entities
            userContextMock.Setup(m => m.Subjects.Remove(It.IsAny<Subjects>())).Callback<Subjects>((entity) => subjects.Remove(entity));

            ISubjectsService? listSubjectsService = new SubjectsService(userContextMock.Object);

            Subjects? deleteSubject = await listSubjectsService.DeleteSubjectAccordingToName("Math");

            var getAllSubjects = listSubjectsService.GetAllSubjects().Count;
            
            Assert.Equal(2, getAllSubjects);
        }

        private static IList<Subjects> GenerateSubjects()
        {
            IList<Subjects> subjects = new List<Subjects>
            {
                fixture.Build<Subjects>().With(u => u.Name, "Math").Create(),
                fixture.Build<Subjects>().With(u => u.Name, "Physics").Create(),
                fixture.Build<Subjects>().With(u => u.Name, "Calculus").Create()
            };
            return subjects;
        }
    }
}
