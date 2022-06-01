using Microsoft.AspNetCore.Mvc;

namespace Private_teaching.Auth.DTO.Requests
{
    public class QuestionAnswersDTO
    {
        public int question_id { get; set; }
        public int selected_option_id { get; set; }
    }
}
