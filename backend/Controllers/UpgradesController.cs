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
        public async Task<ActionResult<IEnumerable<UpgradeReadDto>>> GetUpgradesForUser()
        {
            var userId = Helpers.IdForUser(User);
            var upgrades = await _repository.GetUpgradesForUser(userId);
            return Ok(_mapper.Map<IEnumerable<UpgradeReadDto>>(upgrades));
        }

        [HttpGet("{id}", Name = "GetUpgradeById")]
        public async Task<ActionResult<UpgradeReadDto>> GetUpgradeById(int id)
        {
            var userId = Helpers.IdForUser(User);
            var upgrade = await _repository.GetUpgradeById(id, userId);

            if (upgrade != null)
            {
                return Ok(_mapper.Map<UpgradeReadDto>(upgrade));
            }
            return NotFound();
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<UpgradeTypeReadDto>>> GetUpgradeTypes()
        {
            var upgrades = await _repository.GetUpgradeTypes();
            return Ok(_mapper.Map<IEnumerable<UpgradeTypeReadDto>>(upgrades));
        }

        [HttpPost]
        public async Task<ActionResult<UpgradeReadDto>> CreateUpgradeForUser([FromBody] UpgradeCreateDto upgrade)
        {
            var userId = Helpers.IdForUser(User);
            try
            {
                var upgradeModel = await _repository.CreateUpgradeForUser(upgrade, userId);
                return CreatedAtRoute(
                    nameof(GetUpgradeById),
                    new { Id = upgradeModel.Id },
                    _mapper.Map<UpgradeReadDto>(upgradeModel)
                );
            }
            catch (ArgumentException e)
            {
                return BadRequest(new ErrorResponseDto { Message = e.Message });
            }
        }
    }
}