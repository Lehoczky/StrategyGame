using System;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<UnitReadDto>> GetUnitsForUser()
        {
            var userId = Helpers.IdForUser(User);
            var units = _repository.GetUnitsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }

        [HttpPost]
        public IActionResult CreateUnitsForUser([FromBody] UnitCreateDto units)
        {
            var userId = Helpers.IdForUser(User);

            try
            {
                _repository.CreateUnitsForUser(units, userId);
                return Created("", new { });
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorResponseDto { Message = e.Message });
            }

        }
    }
}