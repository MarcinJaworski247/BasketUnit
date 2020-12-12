using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface IPlayerService
    {
        List<ListPlayersVM> GetPlayers();
        DetailsPlayerVM SetPlayerDetails(int playerId);
        EditPlayerVM EditPlayer(EditPlayerVM model);
        Player AddPlayer(AddPlayerVM model);
        void DeletePlayer(int playerId);
        List<DetailsPlayerVM> GetFirstLineupPlayers();
        List<ListPlayersVM> GetTeamPlayers();
        List<PlayerInjury> GetPlayerInjuries(int playerId);
        void AddPlayerInjury(AddPlayerInjuryVM data);
    }
}
