using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Team AddTeam(AddTeamVM model);
        DetailsTeamVM SetTeamDetails(int teamId);
        EditTeamVM EditTeam(EditTeamVM model);
        List<ListTeamsVM> GetTeams();
        void DeleteTeam(int teamId);
        List<SelectModelBinder<int>> GetTeamsToLookup();
        List<SelectModelBinder<int>> GetPlayersByPosition(int position);
        EditPlayerVM GetFirstLineupPlayerByPosition(int position);
        void SaveFirstLineup(int pointGuardId, int shootingGuardId, int smallForwardId, int powerForwardId, int centerId);
        int GetTeamIdByPlayer(int playerId);
        List<int> GetPlayersIdByTeam(int teamId);
    }
}
