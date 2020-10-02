using System.Collections.Generic;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/players/{playerId}/upgrades")]
    [ApiController]
    public class UpgradesController : ControllerBase
    {
        private readonly IUpgradeRepository _repository;
        private readonly IMapper _mapper;

        public UpgradesController(IUpgradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UpgradeReadDto>> GetUpgradesForPlayer(int playerId)
        {
            var upgrades = _repository.GetUpgradesForPlayer(playerId);
            return Ok(_mapper.Map<IEnumerable<UpgradeReadDto>>(upgrades));
        }
    }
}