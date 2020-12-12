using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class CollegeRepository : Repository<College>, ICollegeRepository
    {
        public CollegeRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MaindatabaseContext
        {
            get { return Context as MainDatabaseContext;  }
        }
        public List<College> GetCollegesList()
        {
            return MaindatabaseContext.Colleges.ToList();
        }
        public List<SelectModelBinder<int>> GetCollegesToLookup()
        {
            List<College> colleges = MaindatabaseContext.Colleges.ToList();
            List<SelectModelBinder<int>> result = colleges.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.City + " " + x.Name
            }).ToList();
            return result;
        }
        public College GetCollege(int collegeId)
        {
            return MaindatabaseContext.Colleges.Where(x => x.Id == collegeId).FirstOrDefault();
        }
        public void AddCollege(College college)
        {
            MaindatabaseContext.Colleges.Add(college);
            MaindatabaseContext.SaveChanges();
        }
        public void DeleteCollege(College college)
        {
            MaindatabaseContext.Colleges.Remove(college);
            MaindatabaseContext.SaveChanges();
        }
        public void EditCollege(College college)
        {
            MaindatabaseContext.Colleges.Update(college);
            MaindatabaseContext.SaveChanges();
        }
    }
}
