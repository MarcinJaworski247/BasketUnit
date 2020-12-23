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
    }
}
