using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        List<College> GetCollegesList();
        List<SelectModelBinder<int>> GetCollegesToLookup();
        College GetCollege(int collegeId);
        void AddCollege(College college);
        void DeleteCollege(College college);
        void EditCollege(College college);
    }
}
