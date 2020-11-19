using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class EditGameVM
    {
        public DateTime Date { get; set; }
        public int ArenaId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int Referee1Id { get; set; }
        public int Referee2Id { get; set; }
    }
}
