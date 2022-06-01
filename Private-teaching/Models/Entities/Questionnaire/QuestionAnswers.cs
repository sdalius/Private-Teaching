using Private_teaching.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Entities.Questionnaire
{
    public class QuestionAnswers
    {
        [Key]
        public int answer_id { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public Teachers Teachers { get; set; }

        public int question_id { get; set; }
        public int question_option_id { get; set; }

        [ForeignKey("question_id, question_option_id")]
        public QuestionOptions QuestionOptions { get; set; }
    }
}
