using BasketUnit.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface INationalityService
    {
        List<SelectModelBinder<int>> GetNationalitiesToLookup();
    }
}
