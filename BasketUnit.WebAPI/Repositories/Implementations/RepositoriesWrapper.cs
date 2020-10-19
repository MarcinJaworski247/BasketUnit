using BasketUnit.WebAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories.Implementations
{
    public class RepositoriesWrapper : IRepositoriesWrapper
    {
        private readonly MainDatabaseContext _context;
        public RepositoriesWrapper(MainDatabaseContext context)
        {
            this._context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
