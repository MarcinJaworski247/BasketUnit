using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class GameDetailsVM
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeamBadge { get; set; }
        public string AwayTeamBadge { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string Arena { get; set; }
        public string FirstReferee { get; set; }
        public string SecondReferee { get; set; }
    }
}
