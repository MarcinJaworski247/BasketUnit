using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Arena : AuditEntity
    {
        public string Name { get; set; }
        public long Capacity { get; set; }
        public string Address { get; set; }
        public virtual Team Team { get; set; }
        public virtual Game Game { get; set; }
    }
}
