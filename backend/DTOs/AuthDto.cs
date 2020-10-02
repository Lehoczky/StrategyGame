using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegistrationFormDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegistrationResponseDto
    {
        public string Message { get; set; }
    }
}