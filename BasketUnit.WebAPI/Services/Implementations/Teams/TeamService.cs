using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public Team AddTeam(AddTeamVM model)
        {
            return RepositoriesWrapper.TeamRepository.AddTeam(model);
        }
        public DetailsTeamVM SetTeamDetails(int teamId)
        {
            return RepositoriesWrapper.TeamRepository.SetTeamDetails(teamId);
        }
        public EditTeamVM EditTeam(EditTeamVM model)
        {
            return RepositoriesWrapper.TeamRepository.EditTeam(model);
        }
        public List<ListTeamsVM> GetTeams()
        {
            return RepositoriesWrapper.TeamRepository.GetTeams();
        }
        public void DeleteTeam(int teamId)
        {
            RepositoriesWrapper.TeamRepository.DeleteTeam(teamId);
        }
        public List<SelectModelBinder<int>> GetTeamsToLookup()
        {
            return RepositoriesWrapper.TeamRepository.GetTeamsToLookup();
        }
        public List<SelectModelBinder<int>> GetPlayersByPosition(int position)
        {
            return RepositoriesWrapper.TeamRepository.GetPlayersByPosition(position);
        }
        public EditPlayerVM GetFirstLineupPlayerByPosition(int position)
        {
            return RepositoriesWrapper.TeamRepository.GetFirstLineupPlayerByPosition(position);
        }
        public void SaveFirstLineup(FirstLineupVM model)
        {
            RepositoriesWrapper.TeamRepository.SaveFirstLineup(model);
        }
        public List<PlayerDetailsChartVM> GetDataToPlayerDetailsChart(int playerId)
        {
            // player avgs
            List<PlayerDetailsChartVM> playerStats = RepositoriesWrapper.StatsRepository.GetAvgStatsByPlayer(playerId);
            // players team
            int teamId = RepositoriesWrapper.TeamRepository.GetTeamIdByPlayer(playerId);
            // teams players
            List<int> teamPlayersIds = RepositoriesWrapper.TeamRepository.GetPlayersIdByTeam(teamId);
            // team players avgs
            List<PlayerDetailsChartVM> dataToChart = RepositoriesWrapper.StatsRepository.GetTeamAvgsToChartData(playerStats, teamPlayersIds);

            return dataToChart;
        }
        public List<GamePlayerStatsVM> GetPlayerLastGameStats(int playerId)
        {
            int teamId = RepositoriesWrapper.TeamRepository.GetTeamIdByPlayer(playerId);
            return RepositoriesWrapper.StatsRepository.GetPlayerLastGameStats(playerId, teamId);
        }
        public FirstLineupVM GetFirstLineupIds()
        {
            return RepositoriesWrapper.TeamRepository.GetFirstLineupIds();
        }
        public List<DetailsPlayerVM> GetFirstLineupPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetFirstLineupPlayers();
        }
        public List<ClosestGamesWidgetVM> GetClosestGamesToWidget()
        {
            return RepositoriesWrapper.TeamRepository.GetClosestGamesToWidget();
        }
        public List<LastGamesVM> GetLastGamesToDashboard()
        {
            return RepositoriesWrapper.TeamRepository.GetLastGamesToDashboard();
        }
        public List<FutureGamesVM> GetFutureGamesToDashboard()
        {
            return RepositoriesWrapper.TeamRepository.GetFutureGamesToDashboard();
        }
        public List<InjuredPlayersVM> GetInjuredPlayersToDashboard()
        {
            return RepositoriesWrapper.TeamRepository.GetInjuredPlayersToDashboard();
        }
        public TeamFormVM GetTeamForm()
        {
            return RepositoriesWrapper.TeamRepository.GetTeamForm();
        }
        public List<PlayerAveragesVM> GetPlayerAvgs(int playerId)
        {
            return RepositoriesWrapper.TeamRepository.GetPlayerAvgs(playerId);
        }
        public List<PlayerRecordsVM> GetPlayerRecords(int playerId)
        {
            return RepositoriesWrapper.TeamRepository.GetPlayerRecords(playerId);
        }
        public List<GamePlayerStatsVM> GetAllPlayerGames(int playerId)
        {
            return RepositoriesWrapper.TeamRepository.GetAllPlayerGames(playerId);
        }
        public List<DataToSpiderWebVM> GetDataToSpiderWeb(int playerId)
        {
            return RepositoriesWrapper.TeamRepository.GetDataToSpiderWeb(playerId);
        }
        public List<FutureWorkoutsVM> GetFutureWorkouts()
        {
            return RepositoriesWrapper.TeamRepository.GetFutureWorkouts();
        }
        public List<FutureGamesVM> GetFutureGamesWithPrediction()
        {
            List<FutureGamesVM> futureGames = RepositoriesWrapper.TeamRepository.GetFutureGamesToDashboard();
            //GameDetailsVM game = RepositoriesWrapper.GameRepository.GetGameDetails(gameId);
            foreach (var game in futureGames)
            {
                GameData gameToPredict = new GameData
                {
                    OpponentId = game.OpponentId,
                    IsHome = game.IsHome
                };
                gameToPredict.IsDayAfterDay = RepositoriesWrapper.GameRepository.IsGameDayAfterDay(teamId: 1, gameDate: game.Date);
                game.PredictionResult = MachineLearningService.PredictGame(gameToPredict);
            }
            return futureGames;
        }
    }
}
