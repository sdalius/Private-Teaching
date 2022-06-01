using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Private_teaching.Auth.DTO.Requests;
using Private_teaching.Auth.DTO.Responses;
using Private_teaching.Auth.Helpers;
using Private_teaching.Helpers;
using Private_teaching.Models.Entities;
using System.Security.Claims;

namespace Private_teaching.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public readonly IMapper _mapper;
        public BookingController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.Student)]
        [HttpGet("/Student/GetBookedTimesOnlyAccordingToOfferID")]
        public async Task<IActionResult> GetBookedTimesOnlyAccordingToOfferID(int offer_id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookedTimes = await _dbContext.BookedTimes
                .Include(x => x.Booking)
                    .Where(x => x.Booking.Offer_Id == offer_id)
                    .Where(x => x.Id == userId).ToListAsync();

            if (bookedTimes != null)
            {
                return Ok(_mapper.Map<List<BookedTimes>, List<BookedTimesOnlyDTOResponse>>(bookedTimes));
            }
            return BadRequest(new Response { Status = "Error", Message = "No booked offers." });
        }

        [Authorize(Roles = UserRoles.Student)]
        [HttpGet("/Student/GetAllBookedOffersDetails")]
        public async Task<IActionResult> GetAllBookedOffersDetails()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookedTimes = await _dbContext.BookedTimes
                                        .Where(x => x.Id == userId)
                                    .Include(x => x.Booking)
                                        .ThenInclude(x => x.Offers)
                                            .ThenInclude(x => x.Subjects)
                                    .Include(x => x.Booking.Offers.Teachers)
                                    .ToListAsync();

            var bookingWithDetails = _mapper.Map<List<BookedTimes>, List<BookingTimeDTOResponse>>(bookedTimes);

            if (bookingWithDetails != null)
            {
                return Ok(bookingWithDetails);
            }
            return BadRequest(new Response { Status = "Error", Message = "No booked times." });
        }

        [Authorize(Roles = UserRoles.Student)]
        [HttpPost("/Student/BookAnOffer")]
        public async Task<IActionResult> BookAnOffer([FromBody] BookTimeDTO model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _dbContext.Students.FindAsync(userId);
            var offer = await _dbContext.Offers.FindAsync(model.Offer_Id);

            if (offer == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Offer was not found." });
            }
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Booking booking = new Booking
                    {
                        Student = user,
                        Offers = offer
                    };
                    await _dbContext.Bookings.AddAsync(booking);
                    _dbContext.SaveChanges();


                    var findBooking = _dbContext.Bookings.Find(booking.booking_Id, offer.Offer_Id);

                    var bookedTimes = _mapper.Map<BookTimeDTO, BookedTimes>(model);
                    bookedTimes.Booking = findBooking;
                    bookedTimes.Student = user;

                    await _dbContext.BookedTimes.AddAsync(bookedTimes);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                    return Ok(new Response { Status = "Success", Message = "Offer was booked successfully!" });
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(new Response { Status = "Error", Message = e.Message });
                }
            }
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/GetBookingsWithDetailsAccordingToOfferID")]
        public async Task<IActionResult> GetBookingsWithDetailsAccordingToBookingID(int offer_id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookedTimes = await _dbContext.BookedTimes
                .Include(x => x.Booking)
                    .ThenInclude(x => x.Offers)
                        .ThenInclude(x => x.Subjects)
                .Where(x => x.Booking.Offer_Id == offer_id)
                .Include(x => x.Booking.Offers.Teachers)
                    .Where(x => x.Booking.Offers.Teachers.Id == userId)
                .Include(x => x.Student)
                .ToListAsync();

            var bookingWithDetails = _mapper.Map<List<BookedTimes>, List<BookingTimeDTOResponse>>(bookedTimes);

            if (bookingWithDetails != null)
            {
                return Ok(bookingWithDetails);
            }
            return BadRequest(new Response { Status = "Error", Message = "No booked times." });
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpGet("/Teacher/GetBookedTimesOnlyAccordingToOfferID")]
        public async Task<IActionResult> GetBookedTimesOnlyAccordingToOfferIDTeacher(int offer_id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookedTimes = await _dbContext.BookedTimes
                .Include(x => x.Booking)
                .Where(x => x.Booking.Offer_Id == offer_id)
                .Include(x => x.Booking.Offers)
                    .ThenInclude(x => x.Teachers)
                .Where(x => x.Booking.Offers.Teachers.Id == userId).ToListAsync();

            if (bookedTimes != null)
            {
                return Ok(_mapper.Map<List<BookedTimes>, List<BookedTimesOnlyDTOResponse>>(bookedTimes));
            }
            return BadRequest(new Response { Status = "Error", Message = "No booked offers." });
        }

        [Authorize(Roles = UserRoles.Teacher)]
        [HttpPost("/Teacher/ApproveBooking")]
        public async Task<IActionResult> ApproveBooking([FromBody] ApproveBookingDTO model)
        {
            var getBooking = _dbContext.Bookings
                .Where(e => e.Offer_Id == model.Offer_Id)
                .Where(e => e.booking_Id == model.booking_id)
                .FirstOrDefault();


            if (getBooking != null)
            {
                getBooking.bApproved = true;

                var result = _dbContext.SaveChanges();

                if (result > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "Booking was approved." });
                }
                else
                {
                    return Ok(new Response { Status = "Warning", Message = "Booking was already approved." });
                }
            }
            return BadRequest(new Response { Status = "Error", Message = "Something is missing." });
        }
    }
}
