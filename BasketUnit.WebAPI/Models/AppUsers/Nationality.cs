using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Nationality : Entity
    {
        public string Name { get; set; }
        public byte[] Flag { get; set; }
    }
}
