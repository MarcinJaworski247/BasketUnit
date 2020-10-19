using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class GameTeams : AuditEntity
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
