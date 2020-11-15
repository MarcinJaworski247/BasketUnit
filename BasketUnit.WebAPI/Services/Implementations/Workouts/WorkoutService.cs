using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public WorkoutService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<Workout> GetWorkouts()
        {
            return RepositoriesWrapper.WorkoutRepository.GetWorkouts();
        }
        public DetailsWorkoutVM SetWorkoutDetails(int workoutId)
        {
            return RepositoriesWrapper.WorkoutRepository.SetWorkoutDetails(workoutId);
        }
        public EditWorkoutVM EditWorkout(EditWorkoutVM model)
        {
            return RepositoriesWrapper.WorkoutRepository.EditWorkout(model);
        }
        public Workout AddWorkout(AddWorkoutVM model)
        {
            return RepositoriesWrapper.WorkoutRepository.AddWorkout(model);
        }
        public void DeleteWorkout(int workoutId)
        {
            RepositoriesWrapper.WorkoutRepository.DeleteWorkout(workoutId);
        }
        public List<SelectModelBinder<int>> GetWorkoutsToLookup()
        {
            return RepositoriesWrapper.WorkoutRepository.GetWorkoutsToLookup();
        }
    }
}
