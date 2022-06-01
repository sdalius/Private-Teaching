using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Models.Entities
{
    [Table("Teachers")]
    public class Teachers : ApplicationUsers
    {
        public double avgRating { get; set; }
        public ICollection<PassedTestsOnSubjects> PassedTestsOnSubjects { get; set; }
    }
}
