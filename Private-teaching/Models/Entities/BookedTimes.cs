using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Models.Entities
{
    public class BookedTimes
    {
        public string Id { get; set; }
        [ForeignKey("Id")]
        public Student? Student { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [Key]
        public int booking_Id { get; set; }

        [ForeignKey("booking_Id,Offer_Id")]
        public Booking Booking { get; set; }
        
    }
}
