using System;
using System.Collections.Generic;
using System.Security.Claims;
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
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var units = _repository.GetUnitsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }
    }
}