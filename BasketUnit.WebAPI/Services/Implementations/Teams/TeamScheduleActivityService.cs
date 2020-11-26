using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class TeamScheduleActivityService : ITeamScheduleActivityService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamScheduleActivityService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public void AddWorkout(AddWorkoutScheduleVM model)
        {
            int teamId = 1;
            TeamSchedule teamSchedule = RepositoriesWrapper.TeamScheduleRepository.GetTeamScheduleByTeam(teamId);
            RepositoriesWrapper.TeamScheduleRepository.AddWorkoutToSchedule(model, teamSchedule);
        }
    }
}
