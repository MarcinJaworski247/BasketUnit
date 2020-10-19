using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public class WorkoutType : AuditEntity
    {
        public WorkoutType()
        {
            Workouts = new List<Workout>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Workout> Workouts { get; set; }
    }
}
