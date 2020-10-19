using BasketUnit.WebAPI.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class GameReferees : AuditEntity
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int RefereeId { get; set; }
        public virtual Referee Referee { get; set; }
    }
}
