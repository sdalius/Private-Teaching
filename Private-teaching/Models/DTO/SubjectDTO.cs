using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Models.DTO
{
    public class SubjectDTO
    {
        public int? Subject_Id { get; set; }

        [Required(ErrorMessage = "Subject name was not entered correctly!")]
        public string Name { get; set; }
    }
}
