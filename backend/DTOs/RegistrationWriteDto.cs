using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegistrationWriteDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}