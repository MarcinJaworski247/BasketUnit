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
        public List<LeagueLeadersWidgetVM> GetLeadersToWidget()
        {
            return RepositoriesWrapper.StatsRepository.GetLeadersToWidget();
        }
    }
}
