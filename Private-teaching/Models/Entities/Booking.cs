using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Models.Entities
{
    [Table("Booking")]
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int booking_Id { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public Student Student { get; set; }
        [Key, Column(Order = 1)]
        public int Offer_Id { get; set; }
        [ForeignKey("Offer_Id")]
        public Offers Offers { get; set; }
        public bool? bApproved { get; set; }
        public bool? bPayed { get; set; }
        public DateTime? bookingTime { get; set; }
        public BookedTimes BookedTimes { get; set; }
    }
}
