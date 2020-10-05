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
        public ActionResult<IEnumerable<BuildingReadDto>> GetBuildingsForUser()
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var buildings = _repository.GetBuildingsForUser(userId);
            return Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }
    }
}