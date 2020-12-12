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
    public class CollegeService : ICollegeService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public CollegeService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<College> GetCollegesList()
        {
            return RepositoriesWrapper.CollegeRepository.GetCollegesList();
        }
        public List<SelectModelBinder<int>> GetCollegesToLookup()
        {
            return RepositoriesWrapper.CollegeRepository.GetCollegesToLookup();
        }
        public DetailsCollegeVM GetCollegeDetails(int collegeId)
        {
            College college = RepositoriesWrapper.CollegeRepository.GetCollege(collegeId);
            DetailsCollegeVM data = new DetailsCollegeVM
            {
                Id = college.Id,
                City = college.City,
                Name = college.Name,
                Badge = college.Badge
            };
            return data;
        }
        public void AddCollege(AddCollegeVM model)
        {
            College college = new College
            {
                City = model.City,
                Name = model.Name,
                Badge = model.Badge
            };
            RepositoriesWrapper.CollegeRepository.AddCollege(college);
        }
        public void EditCollege(EditCollegeVM model)
        {
            College college = RepositoriesWrapper.CollegeRepository.GetCollege(model.Id);
            college.Id = model.Id;
            college.City = model.City;
            college.Name = model.Name;
            college.Badge = model.Badge;
            RepositoriesWrapper.CollegeRepository.EditCollege(college);
        }
        public void DeleteCollege(int collegeId)
        {
            College college = RepositoriesWrapper.CollegeRepository.GetCollege(collegeId);
            RepositoriesWrapper.CollegeRepository.DeleteCollege(college);
        }
    }
}
