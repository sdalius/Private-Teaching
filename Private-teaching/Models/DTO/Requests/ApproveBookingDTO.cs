using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Requests
{
    public class ApproveBookingDTO
    {
        [Required]
        public int booking_id { get; set; }
        [Required]
        public int Offer_Id { get; set; }
    }
}
