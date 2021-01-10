using BasketUnit.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class FutureGamesVM
    {
        public int Id { get; set; }
        public string Badge { get; set; }
        public DateTime Date { get; set; }
        public string Arena { get; set; }
        public Team? HomeTeam { get; set; }
        public Team? AwayTeam { get; set; }
        public Team? OpponentTeam { get; set; }
        public int OpponentId { get; set; }
        public bool IsHome { get; set; }
        public float? PredictionResult { get; set; }
    }
}
