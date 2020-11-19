using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class DetailsGameVM
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Arena { get; set; }
        public string Referee1 { get; set; }
        public string Referee2 { get; set; }
        public string HomeTeamCoach { get; set; }
        public string AwayTeamCoach { get; set; }
        public byte[] HomeTeamBadge { get; set; }
        public byte[] AwayTeamBadge { get; set; }
        public DateTime Date { get; set; }
    }
}
