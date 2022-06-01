using System.ComponentModel.DataAnnotations;

namespace Private_teaching.Auth.DTO.Requests
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "User Name is required!")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "City is required!")]
        public string? City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required!")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
