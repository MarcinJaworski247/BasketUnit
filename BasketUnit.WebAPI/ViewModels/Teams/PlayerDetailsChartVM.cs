using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class PlayerDetailsChartVM
    {
        public string StatType { get; set; }
        public decimal PlayerAvg { get; set; }
        public decimal RestOfTeamAvg { get; set; }
    }
}
