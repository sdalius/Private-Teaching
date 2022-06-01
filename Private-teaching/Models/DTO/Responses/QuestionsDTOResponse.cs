using Private_teaching.Entities.Questionnaire;

namespace Private_teaching.Auth.DTO.Responses
{
    public class QuestionsDTOResponse
    {
        public int question_id { get; set; }
        public string question { get; set; }
        public List<QuestionOptionDTOResponse> Option { get; set; }
    }
}
