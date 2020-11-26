using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class TeamScheduleService : ITeamScheduleService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamScheduleService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<ScheduleActivityVM> GetActivities()
        {
            List<ScheduleActivityVM> games = RepositoriesWrapper.GameRepository.GetGamesToScheduler();
            List<ScheduleActivityVM> workouts = RepositoriesWrapper.TeamScheduleRepository.GetWorkoutsToScheduler(1);
            games.Concat(workouts);
            return games;
        }
    }
}
