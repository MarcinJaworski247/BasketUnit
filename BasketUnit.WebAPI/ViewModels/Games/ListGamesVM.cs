using BasketUnit.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ListGamesVM
    {
        public List<Team> Teams { get; set; }
        public List<Referee> Referees { get; set; }
        public DateTime Date { get; set; }
    }
}
