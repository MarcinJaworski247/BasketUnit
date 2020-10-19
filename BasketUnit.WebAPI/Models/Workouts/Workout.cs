using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class Workout : AuditEntity
    {
        public Workout()
        {
            TeamScheduleActivities = new List<TeamScheduleActivity>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkoutTypeId { get; set; }
        public virtual WorkoutType WorkoutType { get; set; }
        public virtual List<TeamScheduleActivity> TeamScheduleActivities { get; set; }
    }
}
