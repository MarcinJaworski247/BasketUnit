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
        public List<SelectModelBinder<int>> GetPlayersByPosition(int position)
        {
            return RepositoriesWrapper.TeamRepository.GetPlayersByPosition(position);
        }
        public EditPlayerVM GetFirstLineupPlayerByPosition(int position)
        {
            return RepositoriesWrapper.TeamRepository.GetFirstLineupPlayerByPosition(position);
        }
        public void SaveFirstLineup(int pointGuardId, int shootingGuardId, int smallForwardId, int powerForwardId, int centerId)
        {
            RepositoriesWrapper.TeamRepository.SaveFirstLineup(pointGuardId, shootingGuardId, smallForwardId, powerForwardId, centerId);
        }
        public List<PlayerDetailsChartVM> GetDataToPlayerDetailsChart(int playerId)
        {
            List<Stats> playerStats = RepositoriesWrapper.StatsRepository.GetStatsByPlayer(playerId);
            Team team = RepositoriesWrapper.TeamRepository.GetTeamByPlayer(playerId);
            List<Player> restOfTeam = RepositoriesWrapper.TeamRepository.GetPlayersByTeam(team.Id);
            List<Stats> teamStats = RepositoriesWrapper.StatsRepository.GetStatsByTeam(team.Id);

            List<PlayerDetailsChartVM> playerDetailsChart = new List<PlayerDetailsChartVM>();



            return playerDetailsChart;
        }
    }
}
