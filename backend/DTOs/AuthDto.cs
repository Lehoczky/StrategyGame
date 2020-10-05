using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegistrationFormDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }
    }

    public class LoginFormDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class TokenResponseDto
    {
        public string Access { get; set; }
    }

}