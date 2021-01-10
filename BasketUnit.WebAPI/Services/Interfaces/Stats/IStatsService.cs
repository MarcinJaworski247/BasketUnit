using BasketUnit.WebAPI.Enums;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IStatsService
    {
        List<TeamAveragesVM> GetTeamAverages();
        List<ScoreAndLosePointsVM> GetTeamScoreAndLosePoints();
        PlayerCondition GetPlayerCondition(int playerId);
        //void PredictGameResult(int gameId);
    }
}
