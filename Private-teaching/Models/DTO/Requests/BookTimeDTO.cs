using Private_teaching.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Auth.DTO.Requests
{
    public class BookTimeDTO
    {
        public int Offer_Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
