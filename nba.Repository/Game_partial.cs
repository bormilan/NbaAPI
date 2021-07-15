using nba.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace nba.Repository
{
    public partial class Game
    {
        public void Update(GameDTO newGame)
        {
            this.Date = newGame.Date;
            this.HomeTeam = newGame.HomeTeam;
            this.AwayTeam = newGame.AwayTeam;
            this.Winner = newGame.Winner;
        }
    }
}
