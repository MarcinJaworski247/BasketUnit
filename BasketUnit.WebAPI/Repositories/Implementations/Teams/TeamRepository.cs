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
            Arena arena = MainDatabaseContext.Arenas.Where(x => x.Id == team.ArenaId).FirstOrDefault();
            Coach coach = MainDatabaseContext.Coaches.Where(x => x.Id == team.CoachId).FirstOrDefault();
            DetailsTeamVM detailsTeamVM = new DetailsTeamVM
            {
                Id = team.Id,
                City = team.City,
                Name = team.Name,
                FullName = team.City + " " + team.Name,
                Badge = team.Badge,
                CoachFullName = coach != null ? coach.FirstName + " " + coach.LastName : "",
                Arena = arena != null ? arena.Name : "",
                CoachId = team.CoachId,
                ArenaId = team.ArenaId
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
        public List<ListTeamsVM> GetTeams()
        {
            return MainDatabaseContext.Teams.Select(x => new ListTeamsVM() {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Badge = x.Badge,
                CoachId = x.CoachId,
                ArenaId = x.ArenaId
            }).ToList();
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
        public List<SelectModelBinder<int>> GetPlayersByPosition(int position)
        {
            List<Player> players = MainDatabaseContext.Players.Where(x => x.Position == (Enums.Position)position).ToList();
            List<SelectModelBinder<int>> result = players.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.FirstName + " " + x.LastName
            }).ToList();
            return result;
        }
        public EditPlayerVM GetFirstLineupPlayerByPosition(int position)
        {
            Player player = MainDatabaseContext.TeamFirstLineups.Where(x => x.Player.Position == (Enums.Position)position).Select(x => x.Player).FirstOrDefault();
            EditPlayerVM editPlayer = new EditPlayerVM()
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                PlayerNumber = player.Number,
                Avatar = player.Avatar
            };
            return editPlayer;
        }
        public void SaveFirstLineup(int pointGuardId, int shootingGuardId, int smallForwardId, int powerForwardId, int centerId)
        {
            // to do team  parameter
            TeamFirstLineup pointGuard = new TeamFirstLineup
            {
                PlayerId = pointGuardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(pointGuard);
            TeamFirstLineup shootingGuard = new TeamFirstLineup
            {
                PlayerId = shootingGuardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(shootingGuard);
            TeamFirstLineup smallForward = new TeamFirstLineup
            {
                PlayerId = smallForwardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(smallForward);
            TeamFirstLineup powerForward = new TeamFirstLineup
            {
                PlayerId = powerForwardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(powerForward);
            TeamFirstLineup center = new TeamFirstLineup
            {
                PlayerId = centerId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(center);
            MainDatabaseContext.SaveChanges();
        }
        public int GetTeamIdByPlayer(int playerId)
        {
            return MainDatabaseContext.TeamLineups.Where(x => x.PlayerId == playerId).Select(x => x.TeamId).FirstOrDefault();
        }
        public List<int> GetPlayersIdByTeam(int teamId)
        {
            return MainDatabaseContext.TeamLineups.Where(x => x.TeamId == teamId).Select(x => x.PlayerId).ToList(); 
        }
    }
}
