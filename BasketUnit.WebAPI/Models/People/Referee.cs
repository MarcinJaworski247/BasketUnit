using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Referee : Person
    {
        public Referee()
        {
            GameReferees = new List<GameReferees>();
        }
        public DateTime LicenseExpirationDate { get; set; }
        public virtual List<GameReferees> GameReferees { get; set; }
    }
}
