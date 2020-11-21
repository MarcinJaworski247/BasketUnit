using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class NationalityService : INationalityService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public NationalityService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<SelectModelBinder<int>> GetNationalitiesToLookup()
        {
            return RepositoriesWrapper.NationalityRepository.GetNationalitiesToLookup();
        }
    }
}
