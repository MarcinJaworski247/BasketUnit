using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class AddGameVM
    {
        public DateTime GameDateFrom { get; set; }
        public DateTime GameDateTo { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int ArenaId { get; set; }
        public int FirstRefereeId { get; set; }
        public int SecondRefereeId { get; set; }
    }
}
