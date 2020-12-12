using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface ICollegeService
    {
        List<College> GetCollegesList();
        List<SelectModelBinder<int>> GetCollegesToLookup();
        DetailsCollegeVM GetCollegeDetails(int collegeId);
        void AddCollege(AddCollegeVM model);
        void DeleteCollege(int collegeId);
        void EditCollege(EditCollegeVM model);
    }
}
