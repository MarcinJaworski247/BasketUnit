using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface ITeamService
    {
        Team AddTeam(AddTeamVM model);
        DetailsTeamVM SetTeamDetails(int teamId);
        EditTeamVM EditTeam(EditTeamVM model);
        List<Team> GetTeams();
        void DeleteTeam(int teamId);
        List<SelectModelBinder<int>> GetTeamsToLookup();
        List<SelectModelBinder<int>> GetPlayersByPosition(int position);
        EditPlayerVM GetFirstLineupPlayerByPosition(int position);
        void SaveFirstLineup(int pointGuardId, int shootingGuardId, int smallForwardId, int powerForwardId, int centerId);
        List<PlayerDetailsChartVM> GetDataToPlayerDetailsChart(int playerId);
    }
}
