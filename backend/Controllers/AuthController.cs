using System.Threading.Tasks;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegistrationFormDto formData)
        {
            var result = await _repository.register(formData);
            return Ok(result);
        }
    }
}