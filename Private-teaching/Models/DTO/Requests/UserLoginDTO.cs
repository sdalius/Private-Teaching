using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Requests
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
