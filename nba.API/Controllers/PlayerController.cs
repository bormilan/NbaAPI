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
    public class PlayerController : ControllerBase
    {
        private PlayerRepository _repository = null;
        public PlayerController(nba_DB dbContext)
        {
            _repository = new PlayerRepository(dbContext);
        }

        private IActionResult View()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<List<PlayerDTO>> GetAll() =>
            _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<PlayerDTO> Get(int id)
        {
            var player = _repository.Get(id);

            if (player == null)
                return NotFound();

            return player;
        }

        [HttpPost]
        public IActionResult Create(PlayerDTO player)
        {
            player.Id = _repository.Add(player);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PlayerDTO player)
        {
            if (id != player.Id)
                return BadRequest();

            var existingPlayer = _repository.Get(id);
            if (existingPlayer is null)
                return NotFound();

            _repository.Update(player);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = _repository.Get(id);

            if (player is null)
                return NotFound();

            _repository.Delete(id);

            return NoContent();
        }
    }
}
