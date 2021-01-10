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
        public List<ListPlayersVM> GetPlayers()
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
        public List<DetailsPlayerVM> GetFirstLineupPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetFirstLineupPlayers();
        }
        public List<ListPlayersVM> GetTeamPlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetTeamPlayers();
        }
        public List<PlayerInjury> GetPlayerInjuries(int playerId)
        {
            return RepositoriesWrapper.PlayerRepository.GetPlayerInjuries(playerId);
        }
        public void AddPlayerInjury(AddPlayerInjuryVM data)
        {
            RepositoriesWrapper.PlayerRepository.AddPlayerInjury(data);
        }
        public List<DetailsPlayerVM> GetSubstitutePlayers()
        {
            return RepositoriesWrapper.PlayerRepository.GetSubstitutePlayers();
        }
    }
}
