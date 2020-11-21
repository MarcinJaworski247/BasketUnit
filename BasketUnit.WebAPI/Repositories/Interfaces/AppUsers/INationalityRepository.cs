using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        List<SelectModelBinder<int>> GetNationalitiesToLookup();
    }
}
