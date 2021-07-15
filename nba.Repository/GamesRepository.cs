using nba.Core.Models;
using nba.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nba.Core.Models;

namespace nba.Repository
{
    public class GamesRepository
    {
        nba_DB _dbContext = null;
        public GamesRepository(nba_DB context)
        {
            this._dbContext = context;
        }

        public List<GameDTO> GetAll()
        {
            return _dbContext.Games.Select(g => new GameDTO
            {
                Id = g.Id,
                Date = g.Date,
                HomeTeam = g.HomeTeam,
                AwayTeam = g.AwayTeam,
                Winner = g.Winner
            }).ToList();
        }

        public GameDTO Get(int id)
        {
            return _dbContext.Games.Where(g => g.Id == id).Select(g => new GameDTO
            {
                Id = g.Id,
                Date = g.Date,
                HomeTeam = g.HomeTeam,
                AwayTeam = g.AwayTeam,
                Winner = g.Winner
            }).FirstOrDefault();
        }

        public int Add(GameDTO game)
        {
            Game newGame = new Game()
            {
                Date = game.Date,
                HomeTeam = game.HomeTeam,
                AwayTeam = game.AwayTeam,
                Winner = game.Winner
            };

            _dbContext.Games.Add(newGame);
            _dbContext.SaveChanges();

            return newGame.Id;
        }

        public void Delete(int id)
        {
            Game Game = this._dbContext.Games.Where(g => g.Id == id).FirstOrDefault();
            if (Game is null)
                return;

            _dbContext.Games.Remove(Game);
            _dbContext.SaveChanges();
        }

        public void Update(GameDTO newGame)
        {
            Game Game = this._dbContext.Games.Where(g => g.Id == newGame.Id).FirstOrDefault();

            Game.Update(newGame);
            _dbContext.SaveChanges();
        }
    }
}
