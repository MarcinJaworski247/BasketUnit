using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class College : AuditEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public virtual List<Player> Players { get; set; }
        public byte[] Badge { get; set; }
    }
}
