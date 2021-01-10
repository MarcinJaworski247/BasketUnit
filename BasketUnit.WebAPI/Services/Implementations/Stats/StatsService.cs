using BasketUnit.WebAPI.Enums;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class StatsService : IStatsService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public StatsService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<TeamAveragesVM> GetTeamAverages()
        {
            return RepositoriesWrapper.StatsRepository.GetTeamAverages();
        }
        public List<ScoreAndLosePointsVM> GetTeamScoreAndLosePoints()
        {
            return RepositoriesWrapper.StatsRepository.GetTeamScoreAndLosePoints();
        }
        public PlayerCondition GetPlayerCondition(int playerId)
        {
            PlayerStatsAveragesVM oldStats = RepositoriesWrapper.StatsRepository.GetAveragesToCalculateCondition(playerId, 0);
            PlayerStatsAveragesVM lastTwoGamesStats = RepositoriesWrapper.StatsRepository.GetAveragesToCalculateCondition(playerId, 1);

            const int pointsWeight = 3;
            const int assistsWeight = 2;
            const int reboundsWeight = 2;
            const int stealsWeight = 1;
            const int blocksWeight = 1;

            double oldStatsResult = (double)(oldStats.Points * pointsWeight + oldStats.Assists * assistsWeight + oldStats.Rebounds * reboundsWeight + oldStats.Steals * stealsWeight + oldStats.Blocks * blocksWeight)
                                        / (pointsWeight + assistsWeight + reboundsWeight + stealsWeight + blocksWeight);

            double lastTwoGamesStatsResult = (double)(lastTwoGamesStats.Points * pointsWeight + lastTwoGamesStats.Assists * assistsWeight + lastTwoGamesStats.Rebounds * reboundsWeight + lastTwoGamesStats.Steals * stealsWeight + lastTwoGamesStats.Blocks * blocksWeight)
                                        / (pointsWeight + assistsWeight + reboundsWeight + stealsWeight + blocksWeight);

            double difference = lastTwoGamesStatsResult - oldStatsResult;

            if (difference < -1)
                return PlayerCondition.Declining;
            else if (difference > 1)
                return PlayerCondition.Raising;
            else
                return PlayerCondition.Stable;
        }
        //public float PredictGameResult(int gameId)
        //{
        //    GameDetailsVM game = RepositoriesWrapper.GameRepository.GetGameDetails(gameId);
        //    GameData gameToPredict = new GameData
        //    {
        //        OpponentId = game.HomeTeamId == 1 ? game.AwayTeamId : game.HomeTeamId,
        //        IsHome = game.HomeTeamId == 1 ? true : false
        //    };
        //    bool isDayAfterDay = RepositoriesWrapper.GameRepository.IsGameDayAfterDay(teamId: 1, gameDate: game.GameDate);
        //    return MachineLearningService.PredictGame(gameToPredict);
        //}
    }
}
