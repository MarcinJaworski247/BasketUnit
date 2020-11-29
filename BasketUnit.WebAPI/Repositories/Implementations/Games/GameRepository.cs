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
                Teams = x.GameTeams[0].Team.City + " " + x.GameTeams[0].Team.Name + " vs. " + x.GameTeams[1].Team.City + " " + x.GameTeams[1].Team.Name,
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
                    GameId = gameId,
                    Points = 0,
                    Assists = 0,
                    Rebounds = 0,
                    Steals = 0,
                    Blocks = 0,
                    Fouls = 0
                };
                MainDatabaseContext.Stats.Add(stats);
                MainDatabaseContext.SaveChanges();
            }

            foreach (var item in awayTeamLineup)
            {
                Stats stats = new Stats
                {
                    PlayerId = item.PlayerId,
                    GameId = gameId,
                    Points = 0,
                    Assists = 0,
                    Rebounds = 0,
                    Steals = 0,
                    Blocks = 0,
                    Fouls = 0
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

            return data;
        }
        public List<ListAllGamesVM> GetGamesList()
        {
            List<ListAllGamesVM> data = MainDatabaseContext
                .Games
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .Include(x => x.GameReferees)
                .ThenInclude(z => z.Referee)
                .Include(x => x.Arena)
                .Select(x => new ListAllGamesVM
                {
                    Id = x.Id,
                    HomeTeam = x.GameTeams[0].Team.City + " " + x.GameTeams[0].Team.Name,
                    HomeTeamId = x.GameTeams[0].Team.Id,
                    AwayTeam = x.GameTeams[1].Team.City + " " + x.GameTeams[1].Team.Name,
                    AwayTeamId = x.GameTeams[1].Team.Id,
                    Arena = x.Arena.Name,
                    Date = x.Date
                }).ToList();

            foreach(var item in data)
            {
                List<int> homeTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == item.Id && x.Player.TeamLineup.FirstOrDefault().Team.Id == item.HomeTeamId)
                    .Select(x => x.Points).ToList();

                item.HomeTeamPoints = homeTeamPoints.Sum();

                List<int> awayTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == item.Id && x.Player.TeamLineup.FirstOrDefault().Team.Id == item.AwayTeamId)
                    .Select(x => x.Points).ToList();

                item.AwayTeamPoints = awayTeamPoints.Sum();

            }

            return data;
        }
        public GameDetailsVM GetGameDetails(int gameId)
        {
            Game game = MainDatabaseContext.Games
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .Include(x => x.GameReferees)
                .ThenInclude(z => z.Referee)
                .Include(x => x.Arena).Where(x => x.Id == gameId).FirstOrDefault();

            GameDetailsVM data = new GameDetailsVM
            {
                HomeTeam = game.GameTeams[0].Team.City + " " + game.GameTeams[0].Team.Name,
                HomeTeamId = game.GameTeams[0].TeamId,
                AwayTeam = game.GameTeams[1].Team.City + " " + game.GameTeams[1].Team.Name,
                AwayTeamId = game.GameTeams[1].TeamId,
                HomeTeamBadge = Convert.ToBase64String(game.GameTeams[0].Team.Badge), 
                AwayTeamBadge = Convert.ToBase64String(game.GameTeams[1].Team.Badge),
                GameDate = game.Date,
                FirstReferee = game.GameReferees[0].Referee.FirstName + " " + game.GameReferees[0].Referee.LastName,
                SecondReferee = game.GameReferees[1].Referee.FirstName + " " + game.GameReferees[1].Referee.LastName,
                Arena = game.Arena.Name
            };

            List<int> homeTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == game.Id && x.Player.TeamLineup.FirstOrDefault().Team.Id == data.HomeTeamId)
                    .Select(x => x.Points).ToList();

            data.HomeTeamScore = homeTeamPoints.Sum();

            List<int> awayTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == game.Id && x.Player.TeamLineup.FirstOrDefault().Team.Id == data.AwayTeamId)
                    .Select(x => x.Points).ToList();

            data.AwayTeamScore = awayTeamPoints.Sum();

            return data; 
        }
        public List<GameStatsListVM> GetGamePlayersStats(int gameId)
        {
            List<GameStatsListVM> data = MainDatabaseContext.Stats
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.GameId == gameId)
                .Select(x => new GameStatsListVM()
                {
                    Id = x.Id,
                    FullName = x.Player.FirstName + " " + x.Player.LastName,
                    Team = x.Player.TeamLineup.FirstOrDefault().Team.City +  " " + x.Player.TeamLineup.FirstOrDefault().Team.Name,
                    Points = x.Points,
                    Assists = x.Assists, 
                    Rebounds = x.Rebounds,
                    Steals = x.Steals,
                    Blocks = x.Blocks,
                    Fouls = x.Fouls
                }).ToList();
            return data;
        }
        public GamePlayerStatisticsVM GetGamePlayerStatistics(int playerId, int gameId)
        {
            GamePlayerStatisticsVM stats = MainDatabaseContext.Stats
                .Include(x => x.Player)
                .Where(x => x.Id == playerId && x.GameId == gameId)
                .Select(x => new GamePlayerStatisticsVM()
                {
                    Id = x.Id,
                    PlayerId = x.PlayerId,
                    FullName = x.Player.FirstName + " " + x.Player.LastName,
                    Points = x.Points,
                    Assists = x.Assists,
                    Rebounds = x.Rebounds,
                    Steals = x.Steals,
                    Blocks = x.Blocks,
                    Fouls = x.Fouls
                }).FirstOrDefault();

            return stats;
        }
        public void SaveGamePlayerStatistics(GamePlayerStatisticsVM data)
        {
            Stats stats = MainDatabaseContext.Stats.Include(x => x.Player).Where(x => x.Id == data.Id && x.PlayerId == data.PlayerId).FirstOrDefault();
            stats.Points = data.Points;
            stats.Assists = data.Assists;
            stats.Rebounds = data.Rebounds;
            stats.Steals = data.Steals;
            stats.Blocks = data.Blocks;
            stats.Fouls = data.Fouls;

            MainDatabaseContext.Stats.Update(stats);
            MainDatabaseContext.SaveChanges();
        }
    }
}
