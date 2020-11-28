using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
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
            TeamSchedule teamSchedule = new TeamSchedule
            {
                TeamId = team.Id
            };
            MainDatabaseContext.TeamSchedules.Add(teamSchedule);
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

            DetailsTeamVM data = MainDatabaseContext.Teams.Include(x => x.Arena).Include(x => x.Coach).Where(x => x.Id == teamId).Select(x => new DetailsTeamVM()
            {
                Id = team.Id,
                City = team.City,
                Name = team.Name,
                FullName = team.City + " " + team.Name,
                Badge = team.Badge,
                CoachFullName = team.CoachId.HasValue ? team.Coach.FirstName + " " + team.Coach.LastName : " ",
                Arena = team.Arena.Name,
                CoachId = team.CoachId,
                ArenaId = team.ArenaId
            }).FirstOrDefault();

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
        public void SaveFirstLineup(FirstLineupVM model)
        {
            // to do team  parameter

            List<TeamFirstLineup> teamFirstLineup = MainDatabaseContext.TeamFirstLineups.Where(x => x.TeamId == 1).ToList();
            MainDatabaseContext.TeamFirstLineups.RemoveRange(teamFirstLineup);
            MainDatabaseContext.SaveChanges();

            TeamFirstLineup pointGuard = new TeamFirstLineup
            {
                PlayerId = (int)model.PointGuardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(pointGuard);
            TeamFirstLineup shootingGuard = new TeamFirstLineup
            {
                PlayerId = (int)model.ShootingGuardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(shootingGuard);
            TeamFirstLineup smallForward = new TeamFirstLineup
            {
                PlayerId = (int)model.SmallForwardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(smallForward);
            TeamFirstLineup powerForward = new TeamFirstLineup
            {
                PlayerId = (int)model.PowerForwardId,
                TeamId = 1
            };
            MainDatabaseContext.TeamFirstLineups.Add(powerForward);
            TeamFirstLineup center = new TeamFirstLineup
            {
                PlayerId = (int)model.CenterId,
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
        public FirstLineupVM GetFirstLineupIds()
        {
            List<TeamFirstLineup> teamFirstLineups = MainDatabaseContext.TeamFirstLineups.Where(x => x.TeamId == 1).ToList();
            FirstLineupVM firstLineupVM = new FirstLineupVM
            {
                PointGuardId = teamFirstLineups[0].PlayerId,
                ShootingGuardId = teamFirstLineups[1].PlayerId,
                SmallForwardId = teamFirstLineups[2].PlayerId,
                PowerForwardId = teamFirstLineups[3].PlayerId,
                CenterId = teamFirstLineups[4].PlayerId,
            };
            return firstLineupVM;
        }
        public List<ClosestGamesWidgetVM> GetClosestGamesToWidget()
        {
            List<ClosestGamesWidgetVM> closestGamesWidgetVMs = new List<ClosestGamesWidgetVM>();
            List<Game> games = MainDatabaseContext.Games.OrderByDescending(x => x.Date).Take(5).ToList();
            foreach(var item in games)
            {
                List<GameTeams> gt = MainDatabaseContext.GameTeams.Where(x => x.GameId == item.Id).ToList();
                Team homeTeam = gt[0].Team;
                Team awayTeam = gt[1].Team;
                Arena arena = MainDatabaseContext.Arenas.Where(x => x.Id == item.ArenaId).FirstOrDefault();
                ClosestGamesWidgetVM game = new ClosestGamesWidgetVM
                {
                    StartDate = item.Date,
                    HomeTeam = homeTeam.Name,
                    AwayTeam = awayTeam.Name,
                    Arena = arena.Name
                };
                closestGamesWidgetVMs.Add(game);
            }
            return closestGamesWidgetVMs;
        }
    }
}
