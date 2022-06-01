using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Private_teaching.Auth.Helpers;
using Private_teaching.Helpers;
using Private_teaching.Models.DTO;
using Private_teaching.Models.Entities;
using Private_teaching.Services;
using System.Security.Claims;

namespace Private_teaching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListSubjectsController : ControllerBase
    {
        private readonly ISubjectsService _listedSubjectService;
        private readonly IMapper _mapper;
        public ListSubjectsController(ISubjectsService listedSubjectService, IMapper mapper)
        {
            _listedSubjectService = listedSubjectService;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjectList = _listedSubjectService.GetAllSubjects();

            if (subjectList != null)
            {
                return Ok(subjectList);
            }
            return BadRequest(new Response { Status = "Error", Message = "No subjects found in database." });
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/GetSubjectsThatPassedTest")]
        public async Task<IActionResult> GetSubjectsThatPassedTest()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var subjectList = await _listedSubjectService.GetSubjectsThatPassedTest(userId);

            var subjectDTO = _mapper.Map<List<PassedTestsOnSubjects>, List<SubjectDTO>>(subjectList);

            if (subjectDTO != null)
            {
                return Ok(subjectDTO);
            }
            return BadRequest(new Response { Status = "Error", Message = "No passed subjects have been found." });
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/AddSubjectToTeacher")]
        public async Task<IActionResult> AddSubjectToTeacher(int subject_Id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _listedSubjectService.AddSubjectToTeacher(userId,subject_Id);

            if (result > 0)
            {
                return Ok(new Response { Status = "Success", Message = "Subject was added to teacher" });
            }
            return BadRequest(new Response { Status = "Error", Message = "Something went wrong." });
        }
    }
}