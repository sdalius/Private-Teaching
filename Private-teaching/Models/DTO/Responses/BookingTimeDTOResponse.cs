using Private_teaching.Entities;
using Private_teaching.Models.DTO;

namespace Private_teaching.Auth.DTO.Responses
{
    public class BookingTimeDTOResponse
    {
        public int Offer_Id { get; set; }
        public SubjectDTO Subjects { get; set; }
        public TeacherDTOResponse Teachers { get; set; }
        public StudentDTOResponse Student { get; set; }
        public DateTime From { get; set; }  
        public DateTime To { get; set; }
    }
}
