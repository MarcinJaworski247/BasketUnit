﻿using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class TeamFirstLineupRepository : Repository<TeamFirstLineup>, ITeamFirstLineupRepository
    {
        public TeamFirstLineupRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
    }
}
