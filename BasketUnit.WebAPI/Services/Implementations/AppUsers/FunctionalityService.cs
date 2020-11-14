using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class FunctionalityService : IFunctionalityService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public FunctionalityService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
