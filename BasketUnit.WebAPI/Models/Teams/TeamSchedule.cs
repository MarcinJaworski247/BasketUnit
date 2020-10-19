using BasketUnit.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class TeamSchedule : AuditEntity
    {
        public TeamSchedule()
        {
            TeamScheduleActivities = new List<TeamScheduleActivity>();
        }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual List<TeamScheduleActivity> TeamScheduleActivities { get; set; }
    }
}
