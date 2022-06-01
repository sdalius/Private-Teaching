using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Private_teaching.Models.Entities
{
    public class Subjects
    {
        [Key]
        public int Subject_Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string NormalizedName { get; set; }
    }
}
