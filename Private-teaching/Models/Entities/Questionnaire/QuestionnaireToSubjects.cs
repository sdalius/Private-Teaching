using Private_teaching.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Entities.Questionnaire
{
    public class QuestionnaireToSubjects
    {
        [Key]
        public int questionnaire_id { get; set; }

        public int Subject_Id { get; set; }

        [ForeignKey("Subject_Id")]
        public Subjects? Subjects { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
