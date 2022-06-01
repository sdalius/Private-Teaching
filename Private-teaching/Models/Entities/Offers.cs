using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Models.Entities
{
    public class Offers
    {
        [Key]
        public int Offer_Id { get; set; }
        public int Subject_Id { get; set; }
        [ForeignKey("Subject_Id")]
        public Subjects? Subjects { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public Teachers? Teachers { get; set; }
        public decimal Price { get; set; }
        public decimal MinTime { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
