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
    public class WorkoutTypeRepository : Repository<WorkoutType>, IWorkoutTypeRepository
    {
        public WorkoutTypeRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetWorkoutTypesToLookup()
        {
            List<WorkoutType> workoutsType = MainDatabaseContext.WorkoutTypes.ToList();
            List<SelectModelBinder<int>> result = workoutsType.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result;
        }
        public List<WorkoutType> GetWorkoutTypes()
        {
            return MainDatabaseContext.WorkoutTypes.ToList();
        }
        public WorkoutType AddWorkoutType(AddWorkoutTypeVM model)
        {
            WorkoutType workoutType = new WorkoutType
            {
                Name = model.Name,
                Description = model.Description
            };
            MainDatabaseContext.WorkoutTypes.Add(workoutType);
            MainDatabaseContext.SaveChanges();

            return workoutType;
        }
        public DetailsWorkoutTypeVM SetWorkoutTypeDetails(int workoutTypeId)
        {
            WorkoutType workoutType = MainDatabaseContext.WorkoutTypes.Where(x => x.Id == workoutTypeId).FirstOrDefault();
            DetailsWorkoutTypeVM detailsWorkoutTypeVM = new DetailsWorkoutTypeVM
            {
                Id = workoutType.Id,
                Name = workoutType.Name,
                Description = workoutType.Description
            };
            return detailsWorkoutTypeVM;
        }
        public EditWorkoutTypeVM EditWorkoutType(EditWorkoutTypeVM model)
        {
            WorkoutType workoutType = MainDatabaseContext.WorkoutTypes.Where(x => x.Id == model.Id).FirstOrDefault();

            workoutType.Name = model.Name;
            workoutType.Description = model.Description;

            MainDatabaseContext.WorkoutTypes.Update(workoutType);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteWorkoutType(int workoutTypeId)
        {
            WorkoutType workoutType = MainDatabaseContext.WorkoutTypes.Where(x => x.Id == workoutTypeId).FirstOrDefault();
            MainDatabaseContext.WorkoutTypes.Remove(workoutType);
            MainDatabaseContext.SaveChanges();
        }
    }
}
