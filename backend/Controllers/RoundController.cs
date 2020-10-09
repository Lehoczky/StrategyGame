using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/round")]
    [ApiController]
    [Authorize]
    public class RoundController : ControllerBase
    {
        private readonly IRoundRepository _repository;
        private readonly IMapper _mapper;

        public RoundController(IRoundRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<RoundReadDto>> GetRound()
        {
            var round = await _repository.GetRound();
            return Ok(_mapper.Map<RoundReadDto>(round));
        }
    }
}