using Private_teaching.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Private_teaching.Auth.DTO.Responses
{
    public class BookedTimesOnlyDTOResponse
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
