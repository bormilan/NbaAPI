using nba.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace nba.Repository
{
    public partial class Player
    {
        public void Update(PlayerDTO newPlayer)
        {
            this.Id = newPlayer.Id;
            this.Name = newPlayer.Name;
            this.Team = newPlayer.Team;
        }
    }
}
