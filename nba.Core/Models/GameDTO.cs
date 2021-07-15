using System;
using System.Collections.Generic;
using System.Text;

namespace nba.Core.Models
{
    public class GameDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Winner { get; set; }
    }
}
