using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class TeamScheduleRepository : Repository<TeamSchedule>, ITeamScheduleRepository
    {
        public TeamScheduleRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<ScheduleActivityVM> GetWorkoutsToScheduler(int teamId)
        {
            int teamScheduleId = MainDatabaseContext.TeamSchedules.Where(x => x.TeamId == teamId).Select(x => x.Id).FirstOrDefault();
            List<TeamScheduleActivity> teamScheduleActivities = MainDatabaseContext.TeamScheduleActivities.Where(x => x.TeamScheduleId == teamScheduleId).ToList();
            List<ScheduleActivityVM> data = teamScheduleActivities.Select(x => new ScheduleActivityVM()
            {
                Subject = x.Workout.Name + "/ " + x.Workout.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToList();
            return data;
        }
        public TeamSchedule GetTeamScheduleByTeam(int teamId)
        {
            return MainDatabaseContext.TeamSchedules.Where(x => x.TeamId == teamId).FirstOrDefault();
        }
        public void AddWorkoutToSchedule(AddWorkoutScheduleVM model, TeamSchedule teamSchedule)
        {
            TeamScheduleActivity teamScheduleActivity = new TeamScheduleActivity
            {
                TeamScheduleId = teamSchedule.Id,
                WorkoutId = model.ExcerciseId,
                StartDate = model.WorkoutDateFrom,
                EndDate = model.WorkoutDateTo,
                Notes = model.Notes
            };
            MainDatabaseContext.TeamScheduleActivities.Add(teamScheduleActivity);
            MainDatabaseContext.SaveChanges();
        }
    }
}
