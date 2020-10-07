using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/buildings")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<BuildingReadDto>>>  GetBuildingsForUser()
        {
            var userId = Helpers.IdForUser(User);
            var buildings = await _repository.GetBuildingsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }

        [HttpGet("{id}", Name = "GetBuildingById")]
        public async Task<ActionResult<BuildingReadDto>> GetBuildingById(int id)
        {
            var userId = Helpers.IdForUser(User);
            var building = await _repository.GetBuildingById(id, userId);

            if (building != null)
                return Ok(_mapper.Map<BuildingReadDto>(building));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BuildingReadDto>> CreateBuildingForUser([FromBody] BuildingCreateDto building)
        {
            var userId = Helpers.IdForUser(User);

            try
            {
                var model = await _repository.CreateBuildingForUser(building.Name, userId);
                return CreatedAtRoute(
                    nameof(GetBuildingById),
                    new { Id = model.Id },
                    _mapper.Map<BuildingReadDto>(model)
                );
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorResponseDto { Message = e.Message });
            }

        }
    }
}