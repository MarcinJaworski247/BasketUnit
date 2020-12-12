using BasketUnit.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Player : Person
    {
        public Player()
        {
            Stats = new List<Stats>();
            TeamLineup = new List<TeamLineup>();
            TeamFirstLineup = new List<TeamFirstLineup>();
        }
        public Position Position { get; set; }
        public int Number { get; set; }
        public byte[] Avatar { get; set; }
        public virtual List<Stats> Stats { get; set; }
        public virtual List<TeamLineup> TeamLineup { get; set; }
        public virtual List<TeamFirstLineup> TeamFirstLineup { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public virtual List<PlayerInjury> Injuries { get; set; }
        public int? CollegeId { get; set; }
        public College College { get; set; }
    }
}
