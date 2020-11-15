using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IWorkoutRepository : IRepository<Workout>
    {
        List<SelectModelBinder<int>> GetWorkoutsToLookup();
        List<Workout> GetWorkouts();
        Workout AddWorkout(AddWorkoutVM model);
        DetailsWorkoutVM SetWorkoutDetails(int workoutId);
        EditWorkoutVM EditWorkout(EditWorkoutVM model);
        void DeleteWorkout(int workoutId);
    }
}
