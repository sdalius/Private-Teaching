using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Responses
{
    public class OfferDTORequest
    {
        public int Subject_Id { get; set; }
        public decimal Price { get; set; }
        public int MinTime { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
