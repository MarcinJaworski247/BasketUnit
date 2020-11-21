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
    public class RefereeRepository : Repository<Referee>, IRefereeRepository
    {
        public RefereeRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetRefereesToLookup()
        {
            List<Referee> referees = MainDatabaseContext.Referees.ToList();
            List<SelectModelBinder<int>> result = referees.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.FirstName + " " + x.LastName
            }).ToList();
            return result;
        }
        public List<Referee> GetReferees()
        {
            return MainDatabaseContext.Referees.ToList();
        }
        public Referee AddReferee(AddRefereeVM model)
        {
            Referee referee = new Referee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                LicenseExpirationDate = model.LicenseExpirationDate,
                NationalityId = model.NationalityId
            };
            MainDatabaseContext.Referees.Add(referee);
            MainDatabaseContext.SaveChanges();

            return referee;
        }
        public DetailsRefereeVM SetRefereeDetails(int refereeId)
        {
            Referee referee = MainDatabaseContext.Referees.Where(x => x.Id == refereeId).FirstOrDefault();
            DetailsRefereeVM detailsRefereeVM = new DetailsRefereeVM
            {
                Id = referee.Id,
                FirstName = referee.FirstName,
                LastName = referee.LastName,
                FullName = referee.FirstName + " " + referee.LastName,
                LicenseExpirationDate = referee.LicenseExpirationDate,
                BirthDate = referee.BirthDate,
                NationalityId = referee.NationalityId
            };
            return detailsRefereeVM;
        }
        public EditRefereeVM EditReferee(EditRefereeVM model)
        {
            Referee referee = MainDatabaseContext.Referees.Where(x => x.Id == model.Id).FirstOrDefault();

            referee.FirstName = model.FirstName;
            referee.LastName = model.LastName;
            referee.BirthDate = model.BirthDate;
            referee.LicenseExpirationDate = model.LicenseExpirationDate;
            referee.NationalityId = model.NationalityId;

            MainDatabaseContext.Referees.Update(referee);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteReferee(int refereeId)
        {
            Referee referee = MainDatabaseContext.Referees.Where(x => x.Id == refereeId).FirstOrDefault();
            MainDatabaseContext.Referees.Remove(referee);
            MainDatabaseContext.SaveChanges();
        }
    }
}
