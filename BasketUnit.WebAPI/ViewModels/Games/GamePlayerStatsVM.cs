using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class GamePlayerStatsVM
    {
        public int GameId { get; set; }
        public string Opponent { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Fouls { get; set; }
        public DateTime GameTime { get; set; }
    }
}
