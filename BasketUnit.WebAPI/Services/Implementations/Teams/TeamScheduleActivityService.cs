using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class TeamScheduleActivityService : ITeamScheduleActivityService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamScheduleActivityService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
