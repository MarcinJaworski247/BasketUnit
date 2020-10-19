using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models.Teams
{
    public class TeamLineup : AuditEntity
    {
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
