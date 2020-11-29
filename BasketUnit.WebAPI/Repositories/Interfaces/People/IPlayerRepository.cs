using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        List<ListPlayersVM> GetPlayers();
        Player AddPlayer(AddPlayerVM model);
        DetailsPlayerVM SetPlayerDetails(int playerId);
        EditPlayerVM EditPlayer(EditPlayerVM model);
        void DeletePlayer(int playerId);
        List<DetailsPlayerVM> GetFirstLineupPlayers();
        List<ListPlayersVM> GetTeamPlayers();
    }
}
