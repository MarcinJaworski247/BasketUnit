using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface ITeamScheduleRepository : IRepository<TeamSchedule>
    {
        List<ScheduleActivityVM> GetWorkoutsToScheduler(int teamId);
        void AddWorkoutToSchedule(AddWorkoutScheduleVM model, TeamSchedule teamSchedule);
        TeamSchedule GetTeamScheduleByTeam(int teamId);
    }
}
