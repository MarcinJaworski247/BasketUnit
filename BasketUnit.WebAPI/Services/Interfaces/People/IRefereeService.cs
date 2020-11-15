using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IRefereeService
    {
        List<SelectModelBinder<int>> GetRefereesToLookup();
        List<Referee> GetReferees();
        DetailsRefereeVM SetRefereeDetails(int refereeId);
        EditRefereeVM EditReferee(EditRefereeVM model);
        Referee AddReferee(AddRefereeVM model);
        void DeleteReferee(int refereeId);
    }
}
