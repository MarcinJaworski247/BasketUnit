using BasketUnit.WebAPI.Repositories;
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
    }
}
