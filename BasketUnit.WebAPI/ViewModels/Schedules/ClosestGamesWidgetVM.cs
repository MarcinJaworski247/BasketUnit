using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ClosestGamesWidgetVM
    {
        public DateTime StartDate { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Arena { get; set; }
    }
}
