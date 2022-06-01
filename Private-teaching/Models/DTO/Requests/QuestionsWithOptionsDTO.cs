using Microsoft.AspNetCore.Mvc;
using Private_teaching.Auth.DTO.Responses;
using Private_teaching.Entities.Questionnaire;
using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Requests
{
    public class QuestionsWithOptionsDTO
    {
        [Required]
        public int Subject_id { get; set; }
        [Required]
        public string question { get; set; }
        [Required]
        public List<string> questionOptions { get; set; }

    }
}
