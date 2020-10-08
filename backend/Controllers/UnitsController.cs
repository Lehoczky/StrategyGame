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
    [Route("api/units")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<UnitReadDto>>> GetUnitsForUser()
        {
            var userId = Helpers.IdForUser(User);
            var units = await _repository.GetUnitsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }

        [HttpGet("{id}", Name = "GetUnitsById")]
        public async Task<ActionResult<UnitReadDto>> GetUnitsById(int id)
        {
            var userId = Helpers.IdForUser(User);
            var units = await _repository.GetUnitsById(id, userId);

            if (units != null)
            {
                return Ok(_mapper.Map<UnitReadDto>(units));
            }
            return NotFound();
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<UnitTypeReadDto>>> GetUnitTypes()
        {
            var units = await _repository.GetUnitTypes();
            return Ok(_mapper.Map<IEnumerable<UnitTypeReadDto>>(units));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnitsForUser([FromBody] UnitCreateDto units)
        {
            var userId = Helpers.IdForUser(User);

            try
            {
                var model = await _repository.CreateUnitsForUser(units, userId);
                return CreatedAtRoute(
                    nameof(GetUnitsById),
                    new { Id = model.Id },
                    _mapper.Map<UnitReadDto>(model)
                );
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorResponseDto { Message = e.Message });
            }

        }
    }
}