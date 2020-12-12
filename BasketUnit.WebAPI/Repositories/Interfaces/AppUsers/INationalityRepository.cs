using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        List<SelectModelBinder<int>> GetNationalitiesToLookup();
        List<Nationality> GetNationalitiesList();
        Nationality GetNationality(int nationalityId);
        void AddNationality(Nationality nationality);
        void DeleteNationality(Nationality nationality);
        void EditNationality(Nationality nationality);
    }
}
