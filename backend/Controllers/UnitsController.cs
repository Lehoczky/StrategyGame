using System.Collections.Generic;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/players/{playerId}/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitRepository _repository;
        private readonly IMapper _mapper;

        public UnitsController(IUnitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnitReadDto>> GetUnitsForPlayer(int playerId)
        {
            var units = _repository.GetUnitsForPlayer(playerId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }
    }
}