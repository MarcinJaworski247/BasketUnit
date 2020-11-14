using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public PersonService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
