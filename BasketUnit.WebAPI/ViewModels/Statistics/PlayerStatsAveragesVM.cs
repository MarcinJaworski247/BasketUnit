using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class PlayerStatsAveragesVM
    {
        public double? Points { get; set; }
        public double? Assists { get; set; }
        public double? Rebounds { get; set; }
        public double? Steals { get; set; }
        public double? Blocks { get; set; }
    }
}
