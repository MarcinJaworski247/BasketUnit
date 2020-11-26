using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class StatsRepository : Repository<Stats>, IStatsRepository
    {
        public StatsRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<PlayerDetailsChartVM> GetAvgStatsByPlayer(int playerId)
        {
            List<PlayerDetailsChartVM> playerAvgs = new List<PlayerDetailsChartVM>();

            List<int> points = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Points).ToList();
            PlayerDetailsChartVM pointsAvg = new PlayerDetailsChartVM
            {
                StatType = "Points",
                PlayerAvg = (decimal)points.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(pointsAvg);

            List<int> asssist = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Assists).ToList();
            PlayerDetailsChartVM assistsAvg = new PlayerDetailsChartVM
            {
                StatType = "Assists",
                PlayerAvg = (decimal)asssist.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(assistsAvg);

            List<int> rebounds = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Rebounds).ToList();
            PlayerDetailsChartVM reboundsAvg = new PlayerDetailsChartVM
            {
                StatType = "Rebounds",
                PlayerAvg = (decimal)rebounds.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(reboundsAvg);

            List<int> steals = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Steals).ToList();
            PlayerDetailsChartVM stealsAvg = new PlayerDetailsChartVM
            {
                StatType = "Steals",
                PlayerAvg = (decimal)steals.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(stealsAvg);

            List<int> blocks = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Blocks).ToList();
            PlayerDetailsChartVM blocksAvg = new PlayerDetailsChartVM
            {
                StatType = "Steals",
                PlayerAvg = (decimal)blocks.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(blocksAvg);

            return playerAvgs;
        }
        public List<PlayerDetailsChartVM> GetTeamAvgsToChartData(List<PlayerDetailsChartVM> playerStats, List<int> teamPlayersIds)
        {
            List<int> points = MainDatabaseContext.Stats.Where(x => teamPlayersIds.Contains(x.PlayerId)).Select(x => x.Points).ToList();
            List<int> assists = MainDatabaseContext.Stats.Where(x => teamPlayersIds.Contains(x.PlayerId)).Select(x => x.Assists).ToList();
            List<int> rebounds = MainDatabaseContext.Stats.Where(x => teamPlayersIds.Contains(x.PlayerId)).Select(x => x.Rebounds).ToList();
            List<int> steals = MainDatabaseContext.Stats.Where(x => teamPlayersIds.Contains(x.PlayerId)).Select(x => x.Steals).ToList();
            List<int> blocks = MainDatabaseContext.Stats.Where(x => teamPlayersIds.Contains(x.PlayerId)).Select(x => x.Blocks).ToList();

            foreach(var item in playerStats)
            {
                if(item.StatType.Equals("Points"))
                {
                    item.RestOfTeamAvg = (decimal)points.Average();
                }
                else if(item.StatType.Equals("Assists"))
                {
                    item.RestOfTeamAvg = (decimal)assists.Average();
                }
                else if (item.StatType.Equals("Rebounds"))
                {
                    item.RestOfTeamAvg = (decimal)rebounds.Average();
                }
                else if (item.StatType.Equals("Steals"))
                {
                    item.RestOfTeamAvg = (decimal)steals.Average();
                }
                else if (item.StatType.Equals("Blocks"))
                {
                    item.RestOfTeamAvg = (decimal)blocks.Average();
                }
            }
            return playerStats;
        }
        public List<GamePlayerStatsVM> GetPlayerLastGameStats(int playerId, int playerTeamId)
        {
            List<GamePlayerStatsVM> playerStasts = new List<GamePlayerStatsVM>();
            List<Stats> lastStats = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).OrderByDescending(x => x.Id).Take(5).ToList();
            foreach(var item in lastStats)
            {
                GamePlayerStatsVM gamePlayerStatsVM = new GamePlayerStatsVM
                {
                    GameId = item.GameId,
                    Points = item.Points,
                    Assists = item.Assists,
                    Rebounds = item.Rebounds,
                    Steals = item.Steals,
                    Blocks = item.Blocks,
                    GameTime = item.Game.Date,
                    Opponent = MainDatabaseContext.GameTeams.Where(x => x.TeamId != playerTeamId).Select(x => x.Team.Name).FirstOrDefault()
                };
            }
            return playerStasts;
        }
    }
}
