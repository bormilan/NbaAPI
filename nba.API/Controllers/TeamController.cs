using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nba.Core.Models;
using nba.Repository;
using nba.Repository.DataBase;

namespace nba.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private TeamRepository _repository = null;
        public TeamController(nba_DB dbContext)
        {
            _repository = new TeamRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<List<TeamDTO>> GetAll() =>
            _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TeamDTO> Get(int id)
        {
            var team = _repository.Get(id);

            if (team == null)
                return NotFound();

            return team;
        }

        [HttpPost]
        public IActionResult Create(TeamDTO team)
        {
            team.Id = _repository.Add(team);
            return Ok(team);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TeamDTO team)
        {
            if (id != team.Id)
                return BadRequest();

            var existingTeam = _repository.Get(id);
            if (existingTeam is null)
                return NotFound();

            _repository.Update(team);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var team = _repository.Get(id);

            if (team is null)
                return NotFound();

            _repository.Delete(id);

            return NoContent();
        }
    }
}
