using System.Collections.Generic;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/users/{userId}/upgrades")]
    [ApiController]
    public class UpgradesController : ControllerBase
    {
        private readonly IUpgradeRepository _repository;

        public UpgradesController(IUpgradeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Upgrade>> GetUpgradesForUser(int userId)
        {
            return Ok(_repository.GetUpgradesForUser(userId));
        }
    }
}