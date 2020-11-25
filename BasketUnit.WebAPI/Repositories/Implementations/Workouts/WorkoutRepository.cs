using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetWorkoutsToLookup()
        {
            List<Workout> workouts = MainDatabaseContext.Workouts.ToList();
            List<SelectModelBinder<int>> result = workouts.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result;
        }
        public List<Workout> GetWorkouts()
        {
            return MainDatabaseContext.Workouts.ToList();
        }
        public Workout AddWorkout(AddWorkoutVM model)
        {
            Workout workout = new Workout
            {
                Name = model.Name,
                Description = model.Description,
                WorkoutTypeId = model.WorkoutTypeId
            };
            MainDatabaseContext.Workouts.Add(workout);
            MainDatabaseContext.SaveChanges();

            return workout;
        }
        public DetailsWorkoutVM SetWorkoutDetails(int workoutId)
        {
            Workout workout = MainDatabaseContext.Workouts.Where(x => x.Id == workoutId).FirstOrDefault();
            WorkoutType workoutType = MainDatabaseContext.WorkoutTypes.Where(x => x.Id == workout.WorkoutTypeId).FirstOrDefault();
            DetailsWorkoutVM detailsWorkoutVM = new DetailsWorkoutVM
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                WorkoutTypeId = workout.WorkoutTypeId,
                WorkoutType = workoutType.Name
            };
            return detailsWorkoutVM;
        }
        public EditWorkoutVM EditWorkout(EditWorkoutVM model)
        {
            Workout workout = MainDatabaseContext.Workouts.Where(x => x.Id == model.Id).FirstOrDefault();

            workout.Name = model.Name;
            workout.Description = model.Description;
            workout.WorkoutTypeId = model.WorkoutTypeId;

            MainDatabaseContext.Workouts.Update(workout);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteWorkout(int workoutId)
        {
            Workout workout = MainDatabaseContext.Workouts.Where(x => x.Id == workoutId).FirstOrDefault();
            MainDatabaseContext.Workouts.Remove(workout);
            MainDatabaseContext.SaveChanges();
        }
    }
}
