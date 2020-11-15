﻿using BasketUnit.WebAPI.Context;
using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(MainDatabaseContext context) : base(context)
        { }
        private MainDatabaseContext MainDatabaseContext
        {
            get { return Context as MainDatabaseContext; }
        }
        public List<SelectModelBinder<int>> GetCoachesToLookup()
        {
            List<Coach> coaches = MainDatabaseContext.Coaches.ToList();
            List<SelectModelBinder<int>> result = coaches.Select(x => new SelectModelBinder<int>()
            {
                Value = x.Id,
                Text = x.FirstName + " " + x.LastName
            }).ToList();
            return result;
        }
        public List<Coach> GetCoaches()
        {
            return MainDatabaseContext.Coaches.ToList();
        }
        public Coach AddCoach(AddCoachVM model)
        {
            Coach coach = new Coach
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                ExperienceYears = model.ExperienceYears
            };
            MainDatabaseContext.Coaches.Add(coach);
            MainDatabaseContext.SaveChanges();

            return coach;
        }
        public DetailsCoachVM SetCoachDetails(int coachId)
        {
            Coach coach = MainDatabaseContext.Coaches.Where(x => x.Id == coachId).FirstOrDefault();
            DetailsCoachVM detailsCoachVM = new DetailsCoachVM
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                FullName = coach.FirstName + " " + coach.LastName,
                ExperienceYears = coach.ExperienceYears,
                BirthDate = coach.BirthDate
            };
            return detailsCoachVM;
        }
        public EditCoachVM EditCoach(EditCoachVM model)
        {
            Coach coach = MainDatabaseContext.Coaches.Where(x => x.Id == model.Id).FirstOrDefault();

            coach.FirstName = model.FirstName;
            coach.LastName = model.LastName;
            coach.BirthDate = model.BirthDate;
            coach.ExperienceYears = model.ExperienceYears;

            MainDatabaseContext.Coaches.Update(coach);
            MainDatabaseContext.SaveChanges();
            return model;
        }
        public void DeleteCoach(int coachId)
        {
            Coach coach = MainDatabaseContext.Coaches.Where(x => x.Id == coachId).FirstOrDefault();
            MainDatabaseContext.Coaches.Remove(coach);
            MainDatabaseContext.SaveChanges();
        }
    }
}