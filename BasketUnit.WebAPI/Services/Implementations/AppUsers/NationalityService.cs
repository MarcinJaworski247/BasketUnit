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
    public class NationalityService : INationalityService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public NationalityService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<SelectModelBinder<int>> GetNationalitiesToLookup()
        {
            return RepositoriesWrapper.NationalityRepository.GetNationalitiesToLookup();
        }
        public List<Nationality> GetNationalitiesList()
        {
            return RepositoriesWrapper.NationalityRepository.GetNationalitiesList();
        }
        public DetailsNationalityVM GetNationalityDetails(int nationalityId)
        {
            Nationality nationality = RepositoriesWrapper.NationalityRepository.GetNationality(nationalityId);
            DetailsNationalityVM data = new DetailsNationalityVM
            {
                Id = nationality.Id,
                Name = nationality.Name,
                Flag = nationality.Flag
            };
            return data;
        }
        public void DeleteNationality(int nationalityId)
        {
            Nationality nationality = RepositoriesWrapper.NationalityRepository.GetNationality(nationalityId);
            RepositoriesWrapper.NationalityRepository.DeleteNationality(nationality);
        }
        public void AddNationality(AddNationalityVM data)
        {
            Nationality nationality = new Nationality
            {
                Name = data.Name,
                Flag = data.Flag
            };
            RepositoriesWrapper.NationalityRepository.AddNationality(nationality);
        }
        public void EditNationality(EditNationalityVM data)
        {
            Nationality nationality = RepositoriesWrapper.NationalityRepository.GetNationality(data.Id);
            nationality.Name = data.Name;
            nationality.Flag = data.Flag;
            RepositoriesWrapper.NationalityRepository.EditNationality(nationality);
        }
    }
}
