using Microsoft.AspNetCore.Mvc;

namespace Private_teaching.Auth.DTO.Responses
{
    public class QuestionOptionDTOResponse
    {
        public int question_option_id { get; set; }
        public string option { get; set; }
    }
}