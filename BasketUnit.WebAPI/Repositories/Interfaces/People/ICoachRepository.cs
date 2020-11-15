using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface ICoachRepository : IRepository<Coach>
    {
        List<SelectModelBinder<int>> GetCoachesToLookup();
        List<Coach> GetCoaches();
        Coach AddCoach(AddCoachVM model);
        DetailsCoachVM SetCoachDetails(int coachId);
        EditCoachVM EditCoach(EditCoachVM model);
        void DeleteCoach(int coachId);
    }
}
