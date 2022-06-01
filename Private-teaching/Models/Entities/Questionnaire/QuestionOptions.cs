using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Entities.Questionnaire
{
    public class QuestionOptions
    {
        [Key, Column(Order = 0)]
        public int question_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int question_option_id { get; set; }

        [ForeignKey("question_id")]
        public Questions Questions { get; set; }
        public string option { get; set; }
    }
}
