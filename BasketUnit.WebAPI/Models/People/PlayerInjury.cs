using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class PlayerInjury : AuditEntity
    {
        public string Injury { get; set; }
        public DateTime InjuredTo { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
