using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class TeamFirstLineupService : ITeamFirstLineupService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamFirstLineupService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
