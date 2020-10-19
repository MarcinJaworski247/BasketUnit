using BasketUnit.WebAPI.Models.People;
using BasketUnit.WebAPI.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Team : AuditEntity
    {
        public Team()
        {
            TeamLineup = new List<TeamLineup>();
            TeamFirstLineup = new List<TeamFirstLineup>();
            GameTeams = new List<GameTeams>();
        }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual List<TeamLineup> TeamLineup { get; set; }
        public virtual List<TeamFirstLineup> TeamFirstLineup { get; set; }
        public int ArenaId { get; set; }
        public virtual Arena Arena { get; set; }
        public byte[] Badge { get; set; }
        public virtual List<GameTeams> GameTeams { get; set; }
        public virtual TeamSchedule TeamSchedule { get; set; }
        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
