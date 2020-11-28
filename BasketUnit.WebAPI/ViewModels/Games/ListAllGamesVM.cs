using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ListAllGamesVM
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamPoints { get; set; }
        public int AwayTeamPoints { get; set; }
        public string Arena { get; set; }
        public DateTime Date { get; set; }
    }
}
