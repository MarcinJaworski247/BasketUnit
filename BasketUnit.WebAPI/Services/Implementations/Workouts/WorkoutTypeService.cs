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
    public class WorkoutTypeService : IWorkoutTypeService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public WorkoutTypeService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<WorkoutType> GetWorkoutTypes()
        {
            return RepositoriesWrapper.WorkoutTypeRepository.GetWorkoutTypes();
        }
        public DetailsWorkoutTypeVM SetWorkoutTypeDetails(int workoutTypeId)
        {
            return RepositoriesWrapper.WorkoutTypeRepository.SetWorkoutTypeDetails(workoutTypeId);
        }
        public EditWorkoutTypeVM EditWorkoutType(EditWorkoutTypeVM model)
        {
            return RepositoriesWrapper.WorkoutTypeRepository.EditWorkoutType(model);
        }
        public WorkoutType AddWorkoutType(AddWorkoutTypeVM model)
        {
            return RepositoriesWrapper.WorkoutTypeRepository.AddWorkoutType(model);
        }
        public void DeleteWorkoutType(int workoutTypeId)
        {
            RepositoriesWrapper.WorkoutTypeRepository.DeleteWorkoutType(workoutTypeId);
        }
        public List<SelectModelBinder<int>> GetWorkoutTypesToLookup()
        {
            return RepositoriesWrapper.WorkoutTypeRepository.GetWorkoutTypesToLookup();
        }
    }
}
