﻿using BasketUnit.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public AppUserService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
    }
}
