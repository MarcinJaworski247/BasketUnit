using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
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
            List<ScheduleActivityVM> data = MainDatabaseContext.Games.Select(x => new ScheduleActivityVM()
            {
                StartDate = x.Date,
                EndDate = x.Date.AddHours(3),
                Subject = ""
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
    }
}
