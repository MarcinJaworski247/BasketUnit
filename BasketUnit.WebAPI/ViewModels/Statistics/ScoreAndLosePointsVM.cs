using BasketUnit.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ScoreAndLosePointsVM
    {
        public int Id { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public string OpponentName { get; set; }
        public int TeamScore { get; set; }
        public int OpponentScore { get; set; }
        public DateTime? Date { get; set; }
    }
}
