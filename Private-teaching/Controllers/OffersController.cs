using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Private_teaching.Auth.DTO.Responses;
using Private_teaching.Auth.Helpers;
using Private_teaching.Helpers;
using Private_teaching.Models.Entities;

namespace Private_teaching.Controllers
{
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IMapper _mapper;

        public OffersController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.Student)]
        [HttpGet("/Student/GetAllPostedOffers")]
        public async Task<IActionResult> GetAllPostedOffers()
        {
            var offers = await _dbContext.Offers
                .Include(m => m.Teachers)
                .Include(x => x.Subjects)
                .ToListAsync();

            var offersDTO = _mapper.Map<List<Offers>, List<OfferDTOResponse>>(offers);

            return offersDTO == null || offersDTO.Count <= 0 ? NoContent() : Ok(offersDTO);
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpPost("/Teacher/PostAnOffer")]
        public async Task<IActionResult> PostAnOffer([FromBody] OfferDTORequest model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _dbContext.Teachers.FindAsync(userId);

            var subject = await _dbContext.Subjects.FindAsync(model.Subject_Id);

            if (subject != null && user != null)
            {
                var offer = _mapper.Map<OfferDTORequest, Offers>(model);

                offer.Subjects = subject;
                offer.Teachers = user;

                await _dbContext.Offers.AddAsync(offer);
                var result = _dbContext.SaveChanges();

                if (result > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "Offer was posted!" });
                }
            }
            return BadRequest(new Response { Status = "Error", Message = "Offer was not posted." });
        }

        [Authorize(Roles = UserRoles.Student + "," + UserRoles.Teacher)]
        [HttpGet("GetOffersAccordingToSubjectName")]
        public async Task<IActionResult> GetOffersAccordingToSubjectName(string subject_name)
        {
            if (subject_name == null || subject_name.Length <= 0)
            {
                return BadRequest(new Response { Status = "Error", Message = "Subject Name is not defined." });
            }
            if (subject_name.Length >= 20)
            {
                return BadRequest(new Response { Status = "Error", Message = "Subject Name is too big." });
            }
            if (subject_name.Contains(@"^[^\\/:*;\.\)\(]+$"))
            {
                return BadRequest(new Response { Status = "Error", Message = "Subject name contains characters." });
            }

            var offersQuery = await _dbContext.Offers
                .Include(x => x.Subjects)
                    .Where(entity => entity.Subjects.NormalizedName.Contains(subject_name.ToUpper()))
                .Include(x => x.Teachers)
                    .ToListAsync();

            var offersDTO = _mapper.Map<List<Offers>, List<OfferDTOResponse>>(offersQuery);


            return offersDTO == null || offersDTO.Count <= 0
                ? BadRequest(new Response { Status = "Error", Message = "No offers according to the Subject name" })
                : Ok(offersDTO);
        }
    }
}
