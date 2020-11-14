using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class FunctionalityAppRoleService : IFunctionalityAppRoleService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public FunctionalityAppRoleService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
