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
    public class TeamService : ITeamService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public TeamService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public Team AddTeam(AddTeamVM model)
        {
            return RepositoriesWrapper.TeamRepository.AddTeam(model);
        }
        public DetailsTeamVM SetTeamDetails(int teamId)
        {
            return RepositoriesWrapper.TeamRepository.SetTeamDetails(teamId);
        }
        public EditTeamVM EditTeam(EditTeamVM model)
        {
            return RepositoriesWrapper.TeamRepository.EditTeam(model);
        }
        public List<Team> GetTeams()
        {
            return RepositoriesWrapper.TeamRepository.GetTeams();
        }
        public void DeleteTeam(int teamId)
        {
            RepositoriesWrapper.TeamRepository.DeleteTeam(teamId);
        }
        public List<SelectModelBinder<int>> GetTeamsToLookup()
        {
            return RepositoriesWrapper.TeamRepository.GetTeamsToLookup();
        }
    }
}
