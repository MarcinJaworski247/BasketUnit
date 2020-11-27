using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<ScheduleActivityVM> GetGamesToScheduler()
        {
            List<ScheduleActivityVM> data = MainDatabaseContext.Games.Include(x => x.Arena).Include(x => x.GameTeams).ThenInclude(y => y.Team).Select(x => new ScheduleActivityVM()
            {
                StartDate = x.Date,
                EndDate = x.Date.AddHours(3),
                Subject = "",
                HomeTeamBadge = x.GameTeams[0].Team.Badge,
                AwayTeamBadge = x.GameTeams[1].Team.Badge,
                Arena = x.Arena.Name
            }).ToList();
            return data;
        }
        public void AddGameReferees(AddGameVM model, int gameId)
        {
            GameReferees gameReferees1 = new GameReferees
            {
                GameId = gameId,
                RefereeId = model.FirstRefereeId
            };
            MainDatabaseContext.GameReferees.Add(gameReferees1);
            GameReferees gameReferees2 = new GameReferees
            {
                GameId = gameId,
                RefereeId = model.SecondRefereeId
            };
            MainDatabaseContext.GameReferees.Add(gameReferees2);
            MainDatabaseContext.SaveChanges();
        }
        public void AddGameTeams(AddGameVM model, int gameId)
        {
            GameTeams gameTeams1 = new GameTeams
            {
                GameId = gameId,
                TeamId = model.HomeTeamId
            };
            MainDatabaseContext.GameTeams.Add(gameTeams1);
            GameTeams gameTeams2 = new GameTeams
            {
                GameId = gameId,
                TeamId = model.AwayTeamId
            };
            MainDatabaseContext.GameTeams.Add(gameTeams2);
            MainDatabaseContext.SaveChanges();
        }
        public void AddGame(Game model)
        {
            MainDatabaseContext.Games.Add(model);
            MainDatabaseContext.SaveChanges();
        }
        public void AddGameStats(AddGameVM model, int gameId)
        {
            List<TeamLineup> homeTeamLineup = MainDatabaseContext.TeamLineups.Where(x => x.TeamId == model.HomeTeamId).ToList();
            List<TeamLineup> awayTeamLineup = MainDatabaseContext.TeamLineups.Where(x => x.TeamId == model.AwayTeamId).ToList();

            foreach(var item in homeTeamLineup)
            {
                Stats stats = new Stats
                {
                    PlayerId = item.PlayerId,
                    GameId = gameId
                };
                MainDatabaseContext.Stats.Add(stats);
                MainDatabaseContext.SaveChanges();
            }

            foreach (var item in awayTeamLineup)
            {
                Stats stats = new Stats
                {
                    PlayerId = item.PlayerId,
                    GameId = gameId
                };
                MainDatabaseContext.Stats.Add(stats);
                MainDatabaseContext.SaveChanges();
            }
        }
        public List<ClosestGamesWidgetVM> GetClosestGamesToWidget()
        {
            //List<Game> games = MainDatabaseContext.Games.OrderByDescending(x => x.Id).Take(5).ToList();
            //List<ClosestGamesWidgetVM> closestGamesWidgetVMs = new List<ClosestGamesWidgetVM>();
            //List<Arena> arenas = MainDatabaseContext.Arenas.ToList();
            //List<Team> teams = MainDatabaseContext.Teams.ToList();

            //foreach(var item in games)
            //{
            //    List<GameTeams> gameTeams = item.GameTeams.ToList();
            //    ClosestGamesWidgetVM data = new ClosestGamesWidgetVM
            //    {
            //        StartDate = item.Date,
            //        HomeTeam = teams.Where(x => x.Id == gameTeams[0].TeamId).Select(x => x.Name).FirstOrDefault(),
            //        AwayTeam = teams.Where(x => x.Id == gameTeams[1].TeamId).Select(x => x.Name).FirstOrDefault(),
            //        Arena = arenas.Where(x => x.Id == item.ArenaId).Select(x => x.Name).FirstOrDefault()
            //    };
            //    closestGamesWidgetVMs.Add(data);
            //}

            List<ClosestGamesWidgetVM> data = MainDatabaseContext.Games
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(x => new ClosestGamesWidgetVM() {
                    StartDate = x.Date,
                    HomeTeam = x.GameTeams[0].Team.City + " " + x.GameTeams[0].Team.Name,
                    AwayTeam = x.GameTeams[1].Team.City + " " + x.GameTeams[1].Team.Name,
                    Arena = x.Arena.Name
                }).ToList();

            return closestGamesWidgetVMs;
        }
    }
}
