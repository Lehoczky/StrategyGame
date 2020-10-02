using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AuthFormDto
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