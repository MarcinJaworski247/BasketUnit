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
            team.Badge = model.Badge;

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
            List<Player> players = MainDatabaseContext.Players.Include(x => x.TeamLineup).ThenInclude(y => y.Team).Where(x => x.Position == (Enums.Position)position && x.TeamLineup.FirstOrDefault().TeamId == 1).ToList();
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
            List<TeamFirstLineup> teamFirstLineups = MainDatabaseContext.TeamFirstLineups.Include(x => x.Player).Where(x => x.TeamId == 1).ToList();
            FirstLineupVM firstLineupVM = new FirstLineupVM
            {
                PointGuardId = teamFirstLineups.Where(x => x.Player.Position == Enums.Position.PointGuard).Select(x => x.PlayerId).FirstOrDefault(),
                ShootingGuardId = teamFirstLineups.Where(x => x.Player.Position == Enums.Position.ShootingGuard).Select(x => x.PlayerId).FirstOrDefault(),
                SmallForwardId = teamFirstLineups.Where(x => x.Player.Position == Enums.Position.SmallForward).Select(x => x.PlayerId).FirstOrDefault(),
                PowerForwardId = teamFirstLineups.Where(x => x.Player.Position == Enums.Position.PowerForward).Select(x => x.PlayerId).FirstOrDefault(),
                CenterId = teamFirstLineups.Where(x => x.Player.Position == Enums.Position.Center).Select(x => x.PlayerId).FirstOrDefault(),
            };
            return firstLineupVM;
        }
        public List<ClosestGamesWidgetVM> GetClosestGamesToWidget()
        {
            List<ClosestGamesWidgetVM> closestGamesWidgetVMs = new List<ClosestGamesWidgetVM>();
            List<Game> games = MainDatabaseContext.Games.OrderByDescending(x => x.Date).Take(3).ToList();
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
        public List<LastGamesVM> GetLastGamesToDashboard()
        {
            List<LastGamesVM> data = MainDatabaseContext
                .Games
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .Where(x => x.Date < DateTime.Now && ( x.GameTeams.OrderBy(x => x.Id).First().TeamId == 1 || x.GameTeams.OrderBy(x => x.Id).Last().TeamId == 1))
                .Select(x => new LastGamesVM()
                {
                    Id = x.Id,
                    HomeTeam = x.GameTeams[0].Team,
                    AwayTeam = x.GameTeams[1].Team,
                })
                .OrderByDescending(x => x.Id)
                .Take(4)
                .ToList();

            foreach(var item in data)
            {
                item.OpponentTeam = item.HomeTeam.Id != 1 ? item.HomeTeam : item.AwayTeam;
            }
            foreach(var item in data)
            {
                item.Badge = Convert.ToBase64String(item.OpponentTeam.Badge);
            }
            foreach(var item in data)
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
                item.Score = myTeamPoints.ToString() + " : " + opponentTeamPoints.ToString();
                item.IsWin = myTeamPoints > opponentTeamPoints;
                item.Badge = Convert.ToBase64String(item.OpponentTeam.Badge);

                item.OpponentTeam = null;
                item.HomeTeam = null;
                item.AwayTeam = null;
            }
            return data;
        }
        public List<FutureGamesVM> GetFutureGamesToDashboard()
        {
            List<FutureGamesVM> data = MainDatabaseContext.Games
                .Include(x => x.Arena)
                .Include(x => x.GameTeams)
                .ThenInclude(y => y.Team)
                .Where(x => x.Date > DateTime.Now && (x.GameTeams.OrderBy(x => x.Id).First().Id == 1 || x.GameTeams.OrderBy(x => x.Id).Last().Id == 1))
                .Select(x => new FutureGamesVM()
                {
                    Id = x.Id,
                    HomeTeam = x.GameTeams[0].Team,
                    AwayTeam = x.GameTeams[1].Team,
                    Arena = x.Arena.Name,
                    Date = x.Date
                })
                .OrderBy(x => x.Date)
                .Take(4)
                .ToList();
            foreach (var item in data)
            {
                item.OpponentTeam = item.HomeTeam.Id != 1 ? item.HomeTeam : item.AwayTeam;
            }
            foreach (var item in data)
            {
                item.Badge = Convert.ToBase64String(item.OpponentTeam.Badge);
            }
            return data;
        }
        public List<InjuredPlayersVM> GetInjuredPlayersToDashboard()
        {
            return MainDatabaseContext.PlayerInjuries
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Where(x => x.Player.TeamLineup.First().TeamId == 1 && x.InjuredTo > DateTime.Now)
                .Select(x => new InjuredPlayersVM()
                {
                    Id = x.PlayerId,
                    FullName = x.Player.FirstName + " " + x.Player.LastName,
                    Avatar = Convert.ToBase64String(x.Player.Avatar),
                    Injury = x.Injury
                }).ToList();
        }
        public TeamFormVM GetTeamForm()
        {
            return MainDatabaseContext.Teams.Select(x => new TeamFormVM()
            {
                Badge = Convert.ToBase64String(x.Badge),
                Name = x.City + " " + x.Name
            }).FirstOrDefault();
        }
        public List<PlayerAveragesVM> GetPlayerAvgs(int playerId)
        {
            List<PlayerAveragesVM> playerAvgs = new List<PlayerAveragesVM>();

            List<int> points = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Points).ToList();
            PlayerAveragesVM pointsAvg = new PlayerAveragesVM
            {
                StatType = "Punkty",
                Avg = (decimal)points.Average()
            };
            playerAvgs.Add(pointsAvg);

            List<int> asssist = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Assists).ToList();
            PlayerAveragesVM assistsAvg = new PlayerAveragesVM
            {
                StatType = "Asysty",
                Avg = (decimal)asssist.Average()
            };
            playerAvgs.Add(assistsAvg);

            List<int> rebounds = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Rebounds).ToList();
            PlayerAveragesVM reboundsAvg = new PlayerAveragesVM
            {
                StatType = "Zbiórki",
                Avg = (decimal)rebounds.Average()
            };
            playerAvgs.Add(reboundsAvg);

            List<int> steals = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Steals).ToList();
            PlayerAveragesVM stealsAvg = new PlayerAveragesVM
            {
                StatType = "Przechwyty",
                Avg = (decimal)steals.Average()
            };
            playerAvgs.Add(stealsAvg);

            List<int> blocks = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Blocks).ToList();
            PlayerAveragesVM blocksAvg = new PlayerAveragesVM
            {
                StatType = "Bloki",
                Avg = (decimal)blocks.Average()
            };
            playerAvgs.Add(blocksAvg);

            return playerAvgs;
        }
        public List<PlayerRecordsVM> GetPlayerRecords(int playerId)
        {
            List<PlayerRecordsVM> data = new List<PlayerRecordsVM>();
            int points = MainDatabaseContext.Stats.OrderByDescending(x => x.Points).Where(x => x.PlayerId == playerId).Take(1).Select(x => x.Points).FirstOrDefault();
            int assists = MainDatabaseContext.Stats.OrderByDescending(x => x.Assists).Where(x => x.PlayerId == playerId).Take(1).Select(x => x.Assists).FirstOrDefault();
            int rebounds = MainDatabaseContext.Stats.OrderByDescending(x => x.Rebounds).Where(x => x.PlayerId == playerId).Take(1).Select(x => x.Rebounds).FirstOrDefault();
            int steals = MainDatabaseContext.Stats.OrderByDescending(x => x.Steals).Where(x => x.PlayerId == playerId).Take(1).Select(x => x.Steals).FirstOrDefault();
            int blocks = MainDatabaseContext.Stats.OrderByDescending(x => x.Blocks).Where(x => x.PlayerId == playerId).Take(1).Select(x => x.Blocks).FirstOrDefault();

            PlayerRecordsVM pkt = new PlayerRecordsVM
            {
                StatType = "Punkty",
                Score = points
            };
            data.Add(pkt);
            PlayerRecordsVM ast = new PlayerRecordsVM
            {
                StatType = "Asysty",
                Score = assists
            };
            data.Add(ast);
            PlayerRecordsVM reb = new PlayerRecordsVM
            {
                StatType = "Zbiórki",
                Score = rebounds
            };
            data.Add(reb);
            PlayerRecordsVM st = new PlayerRecordsVM
            {
                StatType = "Przechwyty",
                Score = steals
            };
            data.Add(st);
            PlayerRecordsVM blk = new PlayerRecordsVM
            {
                StatType = "Bloki",
                Score = blocks
            };
            data.Add(blk);
            return data;
        }
        public List<GamePlayerStatsVM> GetAllPlayerGames(int playerId)
        {
            List<GamePlayerStatsVM> data = MainDatabaseContext.Stats
                .Include(x => x.Player)
                .ThenInclude(y => y.TeamLineup)
                .ThenInclude(z => z.Team)
                .Include(x => x.Game)
                .OrderByDescending(x => x.Id)
                .Where(x => x.PlayerId == playerId)
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
                    Opponent = x.Game.GameTeams.Where(y => y.TeamId != 1 && y.GameId == x.GameId).Select(y => y.Team.Name).FirstOrDefault()
                }).ToList();

            return data;
        }
        public List<DataToSpiderWebVM> GetDataToSpiderWeb(int playerId)
        {
            List<DataToSpiderWebVM> data = new List<DataToSpiderWebVM>();
            List<int> pointsList = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Points).ToList();
            DataToSpiderWebVM points = new DataToSpiderWebVM
            {
                Arg = "Punkty",
                Val = (decimal)pointsList.Average()
            };
            data.Add(points);
            List<int> assistsList = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Assists).ToList();
            DataToSpiderWebVM assists = new DataToSpiderWebVM
            {
                Arg = "Asysty",
                Val = (decimal)assistsList.Average()
            };
            data.Add(assists);
            List<int> reboundsList = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Rebounds).ToList();
            DataToSpiderWebVM rebounds = new DataToSpiderWebVM
            {
                Arg = "Zbiórki",
                Val = (decimal)reboundsList.Average()
            };
            data.Add(rebounds);
            List<int> stealsList = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Steals).ToList();
            DataToSpiderWebVM steals = new DataToSpiderWebVM
            {
                Arg = "Przechwyty",
                Val = (decimal)stealsList.Average()
            };
            data.Add(steals);
            List<int> blocksList = MainDatabaseContext.Stats.Where(x => x.PlayerId == playerId).Select(x => x.Blocks).ToList();
            DataToSpiderWebVM blocks = new DataToSpiderWebVM
            {
                Arg = "Bloki",
                Val = (decimal)blocksList.Average()
            };
            data.Add(blocks);
            return data;
        }
        public List<FutureWorkoutsVM> GetFutureWorkouts()
        {
            return MainDatabaseContext.TeamScheduleActivities
                .Include(x => x.TeamSchedule)
                .ThenInclude(y => y.Team)
                .Include(x => x.Workout)
                .Where(x => x.TeamSchedule.TeamId == 1 && x.StartDate > DateTime.Now)
                .OrderByDescending(x => x.StartDate)
                .Take(4)
                .Select(x => new FutureWorkoutsVM()
                {
                    Workout = x.Workout.Name,
                    Date = x.StartDate
                }).ToList();
        }
    }
}
