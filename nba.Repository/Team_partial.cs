using nba.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace nba.Repository
{
    public partial class Team
    {
        public void Update(TeamDTO newTeam)
        {
            this.Id = newTeam.Id;
            this.Name = newTeam.Name;
        }
    }
}
