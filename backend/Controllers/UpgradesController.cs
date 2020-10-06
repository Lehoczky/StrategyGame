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
    [Route("api/upgrades")]
    [ApiController]
    [Authorize]
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
        public ActionResult<IEnumerable<UpgradeReadDto>> GetUpgradesForUser()
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var upgrades = _repository.GetUpgradesForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UpgradeReadDto>>(upgrades));
        }

        [HttpGet("{id}", Name = "GetUpgradeById")]
        public ActionResult<UpgradeReadDto> GetUpgradeById(int id)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var upgrade = _repository.GetUpgradeById(id, userId);

            if (upgrade != null)
                return Ok(_mapper.Map<UpgradeReadDto>(upgrade));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UpgradeReadDto> CreateUpgradeForUser([FromBody] UpgradeCreateDto upgrade)
        {
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var upgradeModel = _mapper.Map<Upgrade>(upgrade);

            _repository.CreateUpgradeForUser(upgradeModel, userId);
            return CreatedAtRoute
            (
                nameof(GetUpgradeById),
                new { Id = upgradeModel.Id },
                _mapper.Map<UpgradeReadDto>(upgradeModel)
            );
        }
    }
}