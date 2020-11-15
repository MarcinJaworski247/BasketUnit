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
    public class RefereeService : IRefereeService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public RefereeService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<SelectModelBinder<int>> GetRefereesToLookup()
        {
            return RepositoriesWrapper.RefereeRepository.GetRefereesToLookup();
        }
        public List<Referee> GetReferees()
        {
            return RepositoriesWrapper.RefereeRepository.GetReferees();
        }
        public DetailsRefereeVM SetRefereeDetails(int refereeId)
        {
            return RepositoriesWrapper.RefereeRepository.SetRefereeDetails(refereeId);
        }
        public EditRefereeVM EditReferee(EditRefereeVM model)
        {
            return RepositoriesWrapper.RefereeRepository.EditReferee(model);
        }
        public Referee AddReferee(AddRefereeVM model)
        {
            return RepositoriesWrapper.RefereeRepository.AddReferee(model);
        }
        public void DeleteReferee(int refereeId)
        {
            RepositoriesWrapper.RefereeRepository.DeleteReferee(refereeId);
        }
    }
}
