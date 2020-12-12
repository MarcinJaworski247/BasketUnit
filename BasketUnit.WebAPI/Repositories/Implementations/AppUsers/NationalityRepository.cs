using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        public NationalityRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetNationalitiesToLookup()
        {
            List<Nationality> nationalities = MainDatabaseContext.Nationalities.ToList();
            List<SelectModelBinder<int>> result = nationalities.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result; 
        }
        public List<Nationality> GetNationalitiesList()
        {
            return MainDatabaseContext.Nationalities.ToList();
        }
        public Nationality GetNationality(int nationalityId)
        {
            return MainDatabaseContext.Nationalities.Where(x => x.Id == nationalityId).FirstOrDefault();
        }
        public void AddNationality(Nationality nationality)
        {
            MainDatabaseContext.Nationalities.Add(nationality);
            MainDatabaseContext.SaveChanges();
        }
        public void DeleteNationality(Nationality nationality)
        {
            MainDatabaseContext.Nationalities.Remove(nationality);
            MainDatabaseContext.SaveChanges();
        }
        public void EditNationality(Nationality nationality)
        {
            MainDatabaseContext.Nationalities.Update(nationality);
            MainDatabaseContext.SaveChanges();
        }
    }
}
