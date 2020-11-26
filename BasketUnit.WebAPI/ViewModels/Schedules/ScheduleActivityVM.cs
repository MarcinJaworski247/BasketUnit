using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class ScheduleActivityVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Subject { get; set; }
        public string Excercise { get; set; }
        public string Teams { get; set; }
        public string Arena { get; set; }
        public byte[] HomeTeamBadge { get; set; }
        public byte[] AwayTeamBadge { get; set; }
    }
}
