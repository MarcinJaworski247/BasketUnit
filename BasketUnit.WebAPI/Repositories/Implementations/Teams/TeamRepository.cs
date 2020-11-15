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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public Team AddTeam(AddTeamVM model)
        {
            Team team = new Team
            {
                Name = model.Name,
                Badge = model.Badge,
                City = model.City,
                ArenaId = model.ArenaId,
                CoachId = model.CoachId
            };
            MainDatabaseContext.Teams.Add(team);
            MainDatabaseContext.SaveChanges();

            return team;
        }
        public DetailsTeamVM SetTeamDetails(int teamId)
        {
            Team team = MainDatabaseContext.Teams.Where(x => x.Id == teamId).FirstOrDefault();
            DetailsTeamVM detailsTeamVM = new DetailsTeamVM
            {
                Id = team.Id,
                City = team.City,
                Name = team.Name,
                FullName = team.City + " " + team.Name,
                Badge = team.Badge,
                CoachFullName = team.CoachId.HasValue ? team.Coach.FirstName + " " + team.Coach.LastName : "",
                Arena = team.ArenaId.HasValue ? team.Arena.Name : ""
            };
            return detailsTeamVM;
        }
        public EditTeamVM EditTeam(EditTeamVM model)
        {
            Team team = MainDatabaseContext.Teams.Where(x => x.Id == model.Id).FirstOrDefault();

            team.City = model.City;
            team.Name = model.Name;
            team.CoachId = model.CoachId;
            team.ArenaId = model.ArenaId;

            MainDatabaseContext.Teams.Update(team);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public List<Team> GetTeams()
        {
            return MainDatabaseContext.Teams.ToList();
        }
        public void DeleteTeam(int teamId)
        {
            Team team = MainDatabaseContext.Teams.Where(x => x.Id == teamId).FirstOrDefault();
            MainDatabaseContext.Teams.Remove(team);
            MainDatabaseContext.SaveChanges();
        }
        public List<SelectModelBinder<int>> GetTeamsToLookup()
        {
            List<Team> teams = MainDatabaseContext.Teams.ToList();
            List<SelectModelBinder<int>> result = teams.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.City + " " + x.Name
            }).ToList();
            return result;
        }
    }
}
