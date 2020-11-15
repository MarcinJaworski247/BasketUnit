using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class CoachService : ICoachService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public CoachService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<SelectModelBinder<int>> GetCoachesToLookup()
        {
            return RepositoriesWrapper.CoachRepository.GetCoachesToLookup();
        }
        public List<Coach> GetCoaches()
        {
            return RepositoriesWrapper.CoachRepository.GetCoaches();
        }
        public DetailsCoachVM SetCoachDetails(int coachId)
        {
            return RepositoriesWrapper.CoachRepository.SetCoachDetails(coachId);
        }
        public EditCoachVM EditCoach(EditCoachVM model)
        {
            return RepositoriesWrapper.CoachRepository.EditCoach(model);
        }
        public Coach AddCoach(AddCoachVM model)
        {
            return RepositoriesWrapper.CoachRepository.AddCoach(model);
        }
        public void DeleteCoach(int coachId)
        {
            RepositoriesWrapper.CoachRepository.DeleteCoach(coachId);
        }
    }
}
