using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IWorkoutService
    {
        List<Workout> GetWorkouts();
        DetailsWorkoutVM SetWorkoutDetails(int workoutId);
        EditWorkoutVM EditWorkout(EditWorkoutVM model);
        Workout AddWorkout(AddWorkoutVM model);
        void DeleteWorkout(int workoutId);
        List<SelectModelBinder<int>> GetWorkoutsToLookup();
    }
}
