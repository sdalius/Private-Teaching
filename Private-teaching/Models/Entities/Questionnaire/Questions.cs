using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Entities.Questionnaire
{
    public class Questions
    {
        [Key]
        public int question_id { get; set; }

        public int questionnaire_id { get; set; }
        [ForeignKey("questionnaire_id")]
        public QuestionnaireToSubjects QuestionnaireToSubjects { get; set; }
        public string question { get; set; }
        [ForeignKey("question_option_id")]
        public ICollection<QuestionOptions> QuestionOptions { get; set; }
    }
}
