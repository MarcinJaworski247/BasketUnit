using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.ViewModels
{
    public class AddWorkoutScheduleVM
    {
        public DateTime WorkoutDateFrom { get; set; }
        public DateTime WorkoutDateTo { get; set; }
        public int ExcerciseId { get; set; }
        public string Notes { get; set; }
    }
}
