using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
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
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var units = _repository.GetUnitsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }

        [HttpGet("{id}", Name = "GetUnitById")]
        public ActionResult<UnitReadDto> GetUnitById(int id)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var unit = _repository.GetUnitById(id, userId);

            if (unit != null)
                return Ok(_mapper.Map<UnitReadDto>(unit));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UnitReadDto> CreateUnitForUser([FromBody] UnitCreateDto unit)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var unitModel = _mapper.Map<Unit>(unit);

            _repository.CreateUnitForUser(unitModel, userId);
            return CreatedAtRoute
            (
                nameof(GetUnitById),
                new { Id = unitModel.Id },
                _mapper.Map<UnitReadDto>(unitModel)
            );
        }
    }
}