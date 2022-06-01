using Microsoft.AspNetCore.Mvc;
using Private_teaching.Entities;
using Private_teaching.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Responses
{
    public class OfferDTOResponse
    {
        public int Offer_Id { get; set; }
        public SubjectDTO Subjects { get; set; }
        public TeacherDTOResponse Teachers { get; set; }
        public decimal Price { get; set; }
        public int MinTime { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
