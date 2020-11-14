using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Coach : Person
    {
        public virtual Team Team { get; set; }
        public int? ExperienceYears { get; set; }
    }
}
