using System.Collections.Generic;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllesrs
{
    [Route("api/users/{userId}/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitRepository _repository;

        public UnitsController(IUnitRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Unit>> GetUnitsForUser(int userId)
        {
            return Ok(_repository.GetUnitsForUser(userId));
        }
    }
}