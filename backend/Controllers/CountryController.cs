using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using static backend.Helpers.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/country")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CountryReadDto>> GetCountryForUser()
        {
            var userId = IdForUser(User);
            var country = await _repository.GetCountryForUser(userId);
            return Ok(_mapper.Map<CountryReadDto>(country));
        }
    }
}