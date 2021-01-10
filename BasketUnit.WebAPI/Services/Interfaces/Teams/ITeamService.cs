using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface ITeamService
    {
        Team AddTeam(AddTeamVM model);
        DetailsTeamVM SetTeamDetails(int teamId);
        EditTeamVM EditTeam(EditTeamVM model);
        List<ListTeamsVM> GetTeams();
        void DeleteTeam(int teamId);
        List<SelectModelBinder<int>> GetTeamsToLookup();
        List<SelectModelBinder<int>> GetPlayersByPosition(int position);
        EditPlayerVM GetFirstLineupPlayerByPosition(int position);
        void SaveFirstLineup(FirstLineupVM model);
        List<PlayerDetailsChartVM> GetDataToPlayerDetailsChart(int playerId);
        List<GamePlayerStatsVM> GetPlayerLastGameStats(int playerId);
        FirstLineupVM GetFirstLineupIds();
        List<DetailsPlayerVM> GetFirstLineupPlayers();
        List<ClosestGamesWidgetVM> GetClosestGamesToWidget();
        List<LastGamesVM> GetLastGamesToDashboard();
        List<FutureGamesVM> GetFutureGamesToDashboard();
        List<InjuredPlayersVM> GetInjuredPlayersToDashboard();
        TeamFormVM GetTeamForm();
        List<PlayerAveragesVM> GetPlayerAvgs(int playerId);
        List<PlayerRecordsVM> GetPlayerRecords(int playerId);
        List<GamePlayerStatsVM> GetAllPlayerGames(int playerId);
        List<DataToSpiderWebVM> GetDataToSpiderWeb(int playerId);
        List<FutureWorkoutsVM> GetFutureWorkouts();
        List<FutureGamesVM> GetFutureGamesWithPrediction();
    }
}
