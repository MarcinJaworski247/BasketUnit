using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class PlayerInjuryRepository : Repository<PlayerInjury>, IPlayerInjuryRepository
    {
        public PlayerInjuryRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
    }
}
