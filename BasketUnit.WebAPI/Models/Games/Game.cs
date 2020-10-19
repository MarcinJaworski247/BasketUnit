using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Game : AuditEntity
    {
        public Game()
        {
            GameTeams = new List<GameTeams>();
            Stats = new List<Stats>();
            GameReferees = new List<GameReferees>();
            TeamScheduleActivities = new List<TeamScheduleActivity>();
        }
        public virtual List<GameTeams> GameTeams { get; set; }
        public DateTime Date { get; set; }
        public int ArenaId { get; set; }
        public virtual Arena Arena { get; set; }
        public virtual List<Stats> Stats { get; set; }
        public virtual List<GameReferees> GameReferees { get; set; }
        public virtual List<TeamScheduleActivity> TeamScheduleActivities { get; set; }
    }
}
