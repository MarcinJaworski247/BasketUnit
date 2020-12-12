using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface INationalityService
    {
        List<SelectModelBinder<int>> GetNationalitiesToLookup();
        List<Nationality> GetNationalitiesList();
        DetailsNationalityVM GetNationalityDetails(int nationalityId);
        void DeleteNationality(int nationalityId);
        void AddNationality(AddNationalityVM data);
        void EditNationality(EditNationalityVM data);
    }
}
