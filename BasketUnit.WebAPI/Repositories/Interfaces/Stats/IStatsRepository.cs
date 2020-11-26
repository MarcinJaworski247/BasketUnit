using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IStatsRepository : IRepository<Stats>
    {
        List<PlayerDetailsChartVM> GetAvgStatsByPlayer(int playerId);
        List<PlayerDetailsChartVM> GetTeamAvgsToChartData(List<PlayerDetailsChartVM> playerStats, List<int> teamPlayersIds);
        List<GamePlayerStatsVM> GetPlayerLastGameStats(int playerId, int playerTeamId);
        List<LeagueLeadersWidgetVM> GetLeadersToWidget();
    }
}
