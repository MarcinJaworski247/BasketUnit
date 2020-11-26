using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class LeagueLeadersWidgetVM
    {
        public string StatType { get; set; }
        public string PlayerFullName { get; set; }
        public string Team { get; set; }
        public decimal Score { get; set; }
    }
}
