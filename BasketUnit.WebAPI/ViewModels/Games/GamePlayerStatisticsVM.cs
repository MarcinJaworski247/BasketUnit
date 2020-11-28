using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class GamePlayerStatisticsVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Points { get; set; }
        public int Assist { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Fouls { get; set; }
    }
}
