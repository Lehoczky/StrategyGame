using System;
using System.Threading.Tasks;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
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
            try
            {
                var result = await _repository.Register(formData);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorResponseDto { Message = e.Message });
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginFormDto formData)
        {
            try
            {
                var result = await _repository.Login(formData);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return Unauthorized(new ErrorResponseDto { Message = e.Message });
            }
        }
    }
}