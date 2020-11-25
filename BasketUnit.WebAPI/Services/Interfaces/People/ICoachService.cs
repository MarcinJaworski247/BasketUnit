using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface ICoachService
    {
        List<SelectModelBinder<int>> GetCoachesToLookup();
        List<ListCoachesVM> GetCoaches();
        DetailsCoachVM SetCoachDetails(int coachId);
        EditCoachVM EditCoach(EditCoachVM model);
        Coach AddCoach(AddCoachVM model);
        void DeleteCoach(int coachId);
    }
}
