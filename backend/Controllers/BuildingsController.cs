using System.Collections.Generic;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/players/{playerId}/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;

        public BuildingsController(IBuildingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BuildingReadDto>> GetBuildingsForPlayer(int playerId)
        {
            var buildings = _repository.GetBuildingsForPlayer(playerId);
            return Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }
    }
}