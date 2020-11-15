using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IWorkoutTypeService
    {
        List<WorkoutType> GetWorkoutTypes();
        DetailsWorkoutTypeVM SetWorkoutTypeDetails(int workoutTypeId);
        EditWorkoutTypeVM EditWorkoutType(EditWorkoutTypeVM model);
        WorkoutType AddWorkoutType(AddWorkoutTypeVM model);
        void DeleteWorkoutType(int workoutTypeId);
        List<SelectModelBinder<int>> GetWorkoutTypesToLookup();
    }
}
