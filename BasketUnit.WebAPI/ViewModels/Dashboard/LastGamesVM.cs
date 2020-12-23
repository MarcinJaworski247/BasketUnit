using BasketUnit.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class LastGamesVM
    {
        public int Id { get; set; }
        public bool? IsWin { get; set; }
        public string Score { get; set; }
        public string Badge { get; set; }
        public int? MyTeamScore { get; set; }
        public int? OpponentTeamScore { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public Team? OpponentTeam { get; set; }
    }
}
