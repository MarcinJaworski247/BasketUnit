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

            List<int> points = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).Select(x => x.Points).ToList();
            PlayerDetailsChartVM pointsAvg = new PlayerDetailsChartVM
            {
                StatType = "Points",
                PlayerAvg = (decimal)points.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(pointsAvg);

            List<int> asssist = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).Select(x => x.Assists).ToList();
            PlayerDetailsChartVM assistsAvg = new PlayerDetailsChartVM
            {
                StatType = "Assists",
                PlayerAvg = (decimal)asssist.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(assistsAvg);

            List<int> rebounds = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).Select(x => x.Rebounds).ToList();
            PlayerDetailsChartVM reboundsAvg = new PlayerDetailsChartVM
            {
                StatType = "Rebounds",
                PlayerAvg = (decimal)rebounds.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(reboundsAvg);

            List<int> steals = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).Select(x => x.Steals).ToList();
            PlayerDetailsChartVM stealsAvg = new PlayerDetailsChartVM
            {
                StatType = "Steals",
                PlayerAvg = (decimal)steals.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(stealsAvg);

            List<int> blocks = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).Select(x => x.Blocks).ToList();
            PlayerDetailsChartVM blocksAvg = new PlayerDetailsChartVM
            {
                StatType = "Blocks",
                PlayerAvg = (decimal)blocks.Average(),
                RestOfTeamAvg = 0
            };
            playerAvgs.Add(blocksAvg);

            return playerAvgs;
        }
        public List<PlayerDetailsChartVM> GetTeamAvgsToChartData(List<PlayerDetailsChartVM> playerStats, List<int> teamPlayersIds)
        {
            List<int> points = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => teamPlayersIds.Contains(x.PlayerId) && x.Game.Date < DateTime.Now).Select(x => x.Points).ToList();
            List<int> assists = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => teamPlayersIds.Contains(x.PlayerId) && x.Game.Date < DateTime.Now).Select(x => x.Assists).ToList();
            List<int> rebounds = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => teamPlayersIds.Contains(x.PlayerId) && x.Game.Date < DateTime.Now).Select(x => x.Rebounds).ToList();
            List<int> steals = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => teamPlayersIds.Contains(x.PlayerId) && x.Game.Date < DateTime.Now).Select(x => x.Steals).ToList();
            List<int> blocks = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => teamPlayersIds.Contains(x.PlayerId) && x.Game.Date < DateTime.Now).Select(x => x.Blocks).ToList();

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
            List<GamePlayerStatsVM> data = MainDatabaseContext.Stats
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Include(x => x.Game)
                .OrderByDescending(x => x.Game.Date)
                .Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now)
                .Select(x => new GamePlayerStatsVM()
            {
                GameId = x.GameId,
                Points = x.Points,
                Assists = x.Assists,
                Rebounds = x.Rebounds,
                Steals = x.Steals,
                Blocks = x.Blocks,
                Fouls = x.Fouls,
                GameTime = x.Game.Date,
                Opponent = x.Game.GameTeams.Where(y => y.TeamId != playerTeamId && y.GameId == x.GameId).Select(y => y.Team.Name).FirstOrDefault()
            }).Take(3).ToList();

            return data;
        }
        public List<TeamAveragesVM> GetTeamAverages()
        {
            int pointsAvg = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .ThenInclude(y => y.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Game.Date < DateTime.Now && (x.Game.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.Game.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Points).Sum();

            int pointsSum = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.Game.Date < DateTime.Now)
                .Select(x => x.Points).Sum();

            int assistsAvg = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .ThenInclude(y => y.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Game.Date < DateTime.Now && (x.Game.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.Game.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Assists).Sum();

            int assistsSum = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.Game.Date < DateTime.Now)
                .Select(x => x.Assists).Sum();

            int reboundsAvg = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .ThenInclude(y => y.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Game.Date < DateTime.Now && (x.Game.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.Game.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Rebounds).Sum();

            int reboundsSum = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.Game.Date < DateTime.Now)
                .Select(x => x.Rebounds).Sum();

            int stealsAvg = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .ThenInclude(y => y.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Game.Date < DateTime.Now && (x.Game.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.Game.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Steals).Sum();

            int stealsSum = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.Game.Date < DateTime.Now)
                .Select(x => x.Steals).Sum();

            int blocksAvg = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .ThenInclude(y => y.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Game.Date < DateTime.Now && (x.Game.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.Game.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Blocks).Sum();

            int blocksSum = MainDatabaseContext.Stats
                .Include(x => x.Game)
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.Game.Date < DateTime.Now)
                .Select(x => x.Blocks).Sum();

            int gamesAmount = MainDatabaseContext.Games
                .Include(x => x.GameTeams)
                .ThenInclude(z => z.Team)
                .Where(x => x.Date < DateTime.Now && (x.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => x.Id).Count();

            List<TeamAveragesVM> result = new List<TeamAveragesVM>();
            TeamAveragesVM points = new TeamAveragesVM
            {
                StatType = "Punkty",
                Avg = pointsSum / gamesAmount
            };
            result.Add(points);
            TeamAveragesVM assists = new TeamAveragesVM
            {
                StatType = "Asysty",
                Avg = assistsSum / gamesAmount
            };
            result.Add(assists);
            TeamAveragesVM rebounds = new TeamAveragesVM
            {
                StatType = "Zbiórki",
                Avg = reboundsSum / gamesAmount
            };
            result.Add(rebounds);
            TeamAveragesVM steals = new TeamAveragesVM
            {
                StatType = "Przechwyty",
                Avg = stealsSum / gamesAmount
            };
            result.Add(steals);
            TeamAveragesVM blocks = new TeamAveragesVM
            {
                StatType = "Bloki",
                Avg = blocksSum / gamesAmount
            };
            result.Add(blocks);
            return result;
        }
        public List<ScoreAndLosePointsVM> GetTeamScoreAndLosePoints()
        {
            List<ScoreAndLosePointsVM> data = MainDatabaseContext
                .Games
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .Where(x => x.Date < DateTime.Now && (x.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => new ScoreAndLosePointsVM()
                {
                    Id = x.Id,
                    HomeTeam = x.GameTeams[0].Team,
                    AwayTeam = x.GameTeams[1].Team,
                    Date = x.Date
                })
                .ToList();

            
            foreach (var item in data)
            {
                int myTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == item.Id && x.Player.TeamLineup.First().TeamId == 1)
                    .Select(x => x.Points).Sum();
                int opponentTeamPoints = MainDatabaseContext
                    .Stats
                    .Include(x => x.Player)
                    .ThenInclude(y => y.TeamLineup)
                    .ThenInclude(z => z.Team)
                    .Where(x => x.GameId == item.Id && x.Player.TeamLineup.First().TeamId != 1)
                    .Select(x => x.Points).Sum();
                item.TeamScore = myTeamPoints;
                item.OpponentScore = opponentTeamPoints;
                item.OpponentName = (item.HomeTeam.Id == 1 ? item.AwayTeam.City + " " + item.AwayTeam.Name : item.HomeTeam.City + " " + item.HomeTeam.Name) + " " + item.Date.ToString();
                item.AwayTeam = null;
                item.HomeTeam = null;

            }
            return data;
        }
        public PlayerStatsAveragesVM GetAveragesToCalculateCondition(int playerId, int gamesSpan)
        {
            PlayerStatsAveragesVM result = new PlayerStatsAveragesVM();
            if (gamesSpan == 0)
            {
                List<int> points = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Skip(2).Take(3).Select(x => x.Points).ToList();
                List<int> assists = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Skip(2).Take(3).Select(x => x.Assists).ToList();
                List<int> rebounds = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Skip(2).Take(3).Select(x => x.Rebounds).ToList();
                List<int> steals = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Skip(2).Take(3).Select(x => x.Steals).ToList();
                List<int> blocks = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Skip(2).Take(3).Select(x => x.Blocks).ToList();

                result.Points = points.Average();
                result.Assists = assists.Average();
                result.Rebounds = rebounds.Average();
                result.Steals = steals.Average();
                result.Blocks = blocks.Average();

                return result;
            }
            else if(gamesSpan == 1)
            {
                List<int> points = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Take(2).Select(x => x.Points).ToList();
                List<int> assists = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Take(2).Select(x => x.Assists).ToList();
                List<int> rebounds = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Take(2).Select(x => x.Rebounds).ToList();
                List<int> steals = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Take(2).Select(x => x.Steals).ToList();
                List<int> blocks = MainDatabaseContext.Stats.Include(x => x.Game).Where(x => x.PlayerId == playerId && x.Game.Date < DateTime.Now).OrderByDescending(x => x.Game.Date).Take(2).Select(x => x.Blocks).ToList();

                result.Points = points.Average();
                result.Assists = assists.Average();
                result.Rebounds = rebounds.Average();
                result.Steals = steals.Average();
                result.Blocks = blocks.Average();

                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
