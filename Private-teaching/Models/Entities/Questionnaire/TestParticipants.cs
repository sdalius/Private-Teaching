using Private_teaching.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Entities.Questionnaire
{
    public class TestParticipants
    {
        [Key]
        public int test_id { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public Teachers Teachers { get; set; }

        public int questionnaire_id { get; set; }

        [ForeignKey("questionnaire_id")]
        public QuestionnaireToSubjects QuestionnaireToSubjects { get; set; }
    }
}
