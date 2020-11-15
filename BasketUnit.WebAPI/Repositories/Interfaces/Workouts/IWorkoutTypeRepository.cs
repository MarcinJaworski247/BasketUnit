using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IWorkoutTypeRepository : IRepository<WorkoutType>
    {
        List<SelectModelBinder<int>> GetWorkoutTypesToLookup();
        List<WorkoutType> GetWorkoutTypes();
        WorkoutType AddWorkoutType(AddWorkoutTypeVM model);
        DetailsWorkoutTypeVM SetWorkoutTypeDetails(int workoutTypeId);
        EditWorkoutTypeVM EditWorkoutType(EditWorkoutTypeVM model);
        void DeleteWorkoutType(int workoutTypeId);
    }
}
