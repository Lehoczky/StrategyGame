using System.Collections.Generic;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/users/{userId}/units")]
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
        public ActionResult<IEnumerable<UnitReadDto>> GetUnitsForUser(int userId)
        {
            var units = _repository.GetUnitsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UnitReadDto>>(units));
        }
    }
}