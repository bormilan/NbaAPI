using nba.Core.Models;
using nba.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nba.Repository
{
    public class TeamRepository
    {
        nba_DB _dbContext = null;
        public TeamRepository(nba_DB context)
        {
            this._dbContext = context;
        }

        public List<TeamDTO> GetAll()
        {
            return _dbContext.Teams.Select(t => new TeamDTO
            {
                Id = t.Id,
                Name = t.Name,
                Players = _dbContext.Players.Where(p => p.Team == t.Name).Select(p =>  new PlayerDTO { Id = p.Id,Name = p.Name,Team = p.Team}).ToList()
            }).ToList();
        }

        public TeamDTO Get(int id)
        {
            return _dbContext.Teams.Where(t => t.Id == id).Select(t => new TeamDTO
            {
                Id = t.Id,
                Name = t.Name,
                Players = _dbContext.Players.Where(p => p.Team == t.Name).Select(p => new PlayerDTO { Id = p.Id, Name = p.Name, Team = p.Team }).ToList()
            }).FirstOrDefault();
        }

        public int Add(TeamDTO team)
        {
            Team newTeam = new Team()
            {
                Name = team.Name
            };

            _dbContext.Teams.Add(newTeam);
            _dbContext.SaveChanges();

            return newTeam.Id;
        }

        public void Delete(int id)
        {
            Team team = this._dbContext.Teams.Where(t => t.Id == id).FirstOrDefault();
            if (team is null)
                return;

            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
        }

        public void Update(TeamDTO newTeam)
        {
            Team team = this._dbContext.Teams.Where(t => t.Id == newTeam.Id).FirstOrDefault();

            team.Update(newTeam);
            _dbContext.SaveChanges();
        }
    }
}
