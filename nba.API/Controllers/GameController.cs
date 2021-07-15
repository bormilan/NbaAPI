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
    public class GameController : ControllerBase
    {
        private GamesRepository _repository = null;
        public GameController(nba_DB dbContext)
        {
            _repository = new GamesRepository(dbContext);
        }

        [HttpGet]
        public ActionResult<List<GameDTO>> GetAll() =>
            _repository.GetAll();

        [HttpGet("{id}")]
        public ActionResult<GameDTO> Get(int id)
        {
            var game = _repository.Get(id);

            if (game == null)
                return NotFound();

            return game;
        }

        [HttpPost]
        public IActionResult Create(GameDTO game)
        {
            game.Id = _repository.Add(game);
            return Ok(game);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GameDTO game)
        {
            if (id != game.Id)
                return BadRequest();

            var existingGame = _repository.Get(id);
            if (existingGame is null)
                return NotFound();

            _repository.Update(game);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _repository.Get(id);

            if (game is null)
                return NotFound();

            _repository.Delete(id);

            return NoContent();
        }
    }
}
