using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IRefereeRepository : IRepository<Referee>
    {
        List<SelectModelBinder<int>> GetRefereesToLookup();
        List<Referee> GetReferees();
        Referee AddReferee(AddRefereeVM model);
        DetailsRefereeVM SetRefereeDetails(int refereeId);
        EditRefereeVM EditReferee(EditRefereeVM model);
        void DeleteReferee(int refereeId);

    }
}
