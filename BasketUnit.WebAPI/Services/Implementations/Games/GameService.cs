using BasketUnit.WebAPI.Models;
using BasketUnit.WebAPI.Repositories;
using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public class GameService : IGameService
    {
        private readonly IRepositoriesWrapper RepositoriesWrapper;
        public GameService(IRepositoriesWrapper repositoriesWrapper)
        {
            this.RepositoriesWrapper = repositoriesWrapper;
        }
        public void AddGame(AddGameVM model)
        {
            Game game = new Game
            {
                Date = model.GameDateFrom,
                ArenaId = model.ArenaId
            };
            RepositoriesWrapper.GameRepository.AddGame(game);
            RepositoriesWrapper.GameRepository.AddGameReferees(model, game.Id);
            RepositoriesWrapper.GameRepository.AddGameTeams(model, game.Id);
            RepositoriesWrapper.GameRepository.AddGameStats(model, game.Id);
        }
        public List<ClosestGamesWidgetVM> GetClosestGamesToWidget()
        {
            return RepositoriesWrapper.GameRepository.GetClosestGamesToWidget();
        }
        public List<ListAllGamesVM> GetGamesList()
        {
            return RepositoriesWrapper.GameRepository.GetGamesList();
        }
        public GameDetailsVM GetGameDetails(int gameId)
        {
            return RepositoriesWrapper.GameRepository.GetGameDetails(gameId);
        }
        public List<GameStatsListVM> GetGamePlayersStats(int gameId)
        {
            return RepositoriesWrapper.GameRepository.GetGamePlayersStats(gameId);
        }
        public GamePlayerStatisticsVM GetGamePlayerStatistics(int playerId, int gameId)
        {
            return RepositoriesWrapper.GameRepository.GetGamePlayerStatistics(playerId, gameId);
        }
        public void SaveGamePlayerStatistics(GamePlayerStatisticsVM data)
        {
            RepositoriesWrapper.GameRepository.SaveGamePlayerStatistics(data);
        }
        public List<ListAllGamesVM> GetGamesProtocolsList()
        {
            return RepositoriesWrapper.GameRepository.GetGamesProtocolsList();
        }
    }
}
