using System.Collections.Generic;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> GetAllPlayers()
        {
            var players = _repository.GetAllPlayers();
            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerReadDto> GetPlayerById(int id)
        {
            var player = _repository.GetPlayerById(id);
            return Ok(_mapper.Map<PlayerReadDto>(player));
        }
    }
}