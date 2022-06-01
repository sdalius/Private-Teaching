using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Models.Entities
{
    public class PassedTestsOnSubjects
    {
        [Key, Column(Order = 0)]
        public int Subject_Id { get; set; }
        [ForeignKey("Subject_Id")]
        public Subjects Subjects { get; set; }

        [Key, Column(Order = 1)]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public Teachers Teachers { get; set; }

        public bool? hasPassed { get; set; }
    }
}
