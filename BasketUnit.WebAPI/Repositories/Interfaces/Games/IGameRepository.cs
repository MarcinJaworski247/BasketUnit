using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        List<ScheduleActivityVM> GetGamesToScheduler();
        void AddGame(Game model);
        void AddGameTeams(AddGameVM model, int gameId);
        void AddGameReferees(AddGameVM model, int gameId);
        void AddGameStats(AddGameVM model, int gameId);
        List<ClosestGamesWidgetVM> GetClosestGamesToWidget();
        List<ListAllGamesVM> GetGamesList();
        GameDetailsVM GetGameDetails(int gameId);
        List<GameStatsListVM> GetGamePlayersStats(int gameId);
        GamePlayerStatisticsVM GetGamePlayerStatistics(int playerId, int gameId);
        void SaveGamePlayerStatistics(GamePlayerStatisticsVM data);
        List<ListAllGamesVM> GetGamesProtocolsList();
    }
}
