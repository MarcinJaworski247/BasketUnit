using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class AddPlayerInjuryVM
    {
        public int PlayerId { get; set; }
        public DateTime AddInjuredTo { get; set; }
        public string AddInjury { get; set; }
    }
}
