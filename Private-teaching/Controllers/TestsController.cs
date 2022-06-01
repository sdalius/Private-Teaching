using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Private_teaching.Auth.DTO.Requests;
using Private_teaching.Auth.DTO.Responses;
using Private_teaching.Auth.Helpers;
using Private_teaching.Entities.Questionnaire;
using Private_teaching.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;

namespace Private_teaching.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IMapper _mapper;
        public TestsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/AddQuestionnaireToSubjects")]
        public async Task<IActionResult> AddQuestionnaireToSubjects(int subject_id)
        {
            var bExists = _dbContext.QuestionnaireToSubjects.FirstOrDefault(p => p.Subject_Id == subject_id);

            if (bExists != null)
            {
                return Ok(new Response { Status = "Error", Message = "Subject is already linked to questionnaire!" });
            }

            await _dbContext.QuestionnaireToSubjects.AddAsync(new QuestionnaireToSubjects
            {
                Subject_Id = subject_id
            });
            var result = _dbContext.SaveChanges();

            if (result > 0)
            {
                return Ok(_dbContext.QuestionnaireToSubjects.First(e => e.Subject_Id == subject_id));
            }
            return BadRequest(new Response { Status = "Error", Message = "Something went wrong" });
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/TakeTest")]
        public async Task<IActionResult> TakeTest(int subject_id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var findQuestionnaire = _dbContext.QuestionnaireToSubjects.First(e => e.Subject_Id == subject_id);

            if (findQuestionnaire == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "There are no questionnaires linked to this subject." });
            }

            var addParticipant = await _dbContext.TestParticipants.AddAsync(new TestParticipants
            {
                Id = userId,
                questionnaire_id = findQuestionnaire.questionnaire_id
            });

            var result = _dbContext.SaveChanges();

            if (result > 0)
            {
                var questionsForTest = _dbContext.Questions
                    .Include(e => e.QuestionnaireToSubjects)
                    .Where(e => e.QuestionnaireToSubjects.Subject_Id == subject_id)
                    .Where(e => e.questionnaire_id == e.QuestionnaireToSubjects.questionnaire_id)
                    .Select(e => new QuestionsDTOResponse
                    {
                        question_id = e.question_id,
                        question = e.question,
                        Option = _mapper.Map<List<QuestionOptions>, List<QuestionOptionDTOResponse>>(e.QuestionOptions.ToList())
                    });
                return Ok(questionsForTest);
            }
            return BadRequest(new Response { Status = "Error", Message = "Something went wrong." });
        }

        // Recheck it
        [Authorize(Roles = UserRoles.Teacher)]
        [HttpPost("/Teacher/AddNewQuestionWithOptions")]
        public async Task<IActionResult> AddNewQuestionWithOptions([FromBody] QuestionsWithOptionsDTO model)
        {
            var findQuestionnaireId = _dbContext.QuestionnaireToSubjects.First(e => e.Subject_Id == model.Subject_id);

            if (findQuestionnaireId == null)
            {
                return Ok(new Response { Status = "Error", Message = "Subject is not linked to any questionnaire!" });
            }

            var insertQuestion = _dbContext.Questions.AddAsync(
                new Questions
                {
                    QuestionnaireToSubjects = findQuestionnaireId,
                    question = model.question
                });
            var result = _dbContext.SaveChanges();

            if (result < 0)
            {
                return BadRequest(new Response { Status = "Error", Message = "Question was not inserted." });
            }

            var question = _dbContext.Questions.First(e => e.question.Equals(model.question));

            foreach (var item in model.questionOptions)
            {
                await _dbContext.QuestionOptions.AddAsync(new QuestionOptions
                {
                    question_id = question.question_id,
                    option = item
                });
            }

            var optionsAdded = _dbContext.SaveChanges();

            if (optionsAdded > 0)
            {
                return Ok(new Response { Status = "Success", Message = "Question with options has been inserted." });
            }

            return BadRequest(new Response { Status = "Error", Message = "Something went wrong." });
        }


        [Authorize(Roles = UserRoles.Teacher)]
        [HttpPost("/Teacher/SubmitAnswers")]
        public async Task<IActionResult> SubmitAnswers([FromBody] List<QuestionAnswersDTO> model)
        {
            if (model.Count < 0 || model == null)
            {
                return BadRequest(new Response
                {
                    Status = "Error",
                    Message = "Answers are empty"
                });
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var item in model)
            {
                await _dbContext.QuestionAnswers.AddAsync(new QuestionAnswers
                {
                    Id = userId,
                    question_id = item.question_id,
                    question_option_id = item.selected_option_id
                });
            }

            var result = _dbContext.SaveChanges();

            if (result > 0)
            {
                return Ok(new Response
                {
                    Status = "Success",
                    Message = "Answers were submitted successfully!"
                });
            }

            return BadRequest(new Response
            {
                Status = "Error",
                Message = "Something went wrong."
            });
        }
    }
}
