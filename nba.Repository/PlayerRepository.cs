using nba.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using nba.Repository.DataBase;

namespace nba.Repository
{
    public class PlayerRepository
    {
        nba_DB _dbContext = null;
        public PlayerRepository(nba_DB context)
        {
            this._dbContext = context;
        }

        public List<PlayerDTO> GetAll()
        {
            return _dbContext.Players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Team = p.Team
            }).ToList();
        }

        public PlayerDTO Get(int id)
        {
            return _dbContext.Players.Where(p => p.Id == id).Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Team = p.Team
            }).FirstOrDefault();
        }

        public int Add(PlayerDTO player)
        {
            Player newPlayer = new Player()
            {
                Name = player.Name,
                Team = player.Team
            };

            _dbContext.Players.Add(newPlayer);
            _dbContext.SaveChanges();

            return newPlayer.Id;
        }

        public void Delete(int id)
        {
            Player player = this._dbContext.Players.Where(p => p.Id == id).FirstOrDefault();
            if (player is null)
                return;

            _dbContext.Players.Remove(player);
            _dbContext.SaveChanges();
        }

        public void Update(PlayerDTO newPlayer)
        {
            Player player = this._dbContext.Players.Where(p => p.Id == newPlayer.Id).FirstOrDefault();

            player.Update(newPlayer);
            _dbContext.SaveChanges();
        }
    }
}
