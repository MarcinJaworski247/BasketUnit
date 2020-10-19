using BasketUnit.WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class TeamScheduleActivity : AuditEntity
    {
        public int TeamScheduleId { get; set; }
        public virtual TeamSchedule TeamSchedule { get; set; }
        public int? WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
