using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public PlayerService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public List<Player> GetPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetPlayers();
        }
        public DetailsPlayerVM SetPlayerDetails(int playerId)
        {
            return RepositoriesWrapper.PlayerRepository.SetPlayerDetails(playerId);
        }
        public EditPlayerVM EditPlayer(EditPlayerVM model)
        {
            return RepositoriesWrapper.PlayerRepository.EditPlayer(model);
        }
        public Player AddPlayer(AddPlayerVM model)
        {
            return RepositoriesWrapper.PlayerRepository.AddPlayer(model);
        }
        public void DeletePlayer(int playerId)
        {
            RepositoriesWrapper.PlayerRepository.DeletePlayer(playerId);
        }
        public List<Player> GetFirstLineupPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetFirstLineupPlayers();
        }
    }
}
