using BasketUnit.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Functionality : AuditEntity
    {
        public Functionality()
        {
            FunctionalityAppRoles = new List<FunctionalityAppRole>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public FunctionalityType FunctionalityType { get; set; }
        public virtual List<FunctionalityAppRole> FunctionalityAppRoles { get; set; }
    }
}
