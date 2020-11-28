using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService GameService;
        public GameController(IGameService gameService)
        {
            this.GameService = gameService;
        }
        [HttpGet("getGamesList")]
        public ActionResult GetGamesList()
        {
            var data = GameService.GetGamesList();
            return Ok(data);
        }
        [HttpGet("getGameDetails/{gameId}")]
        public ActionResult GetGameDetails(int gameId)
        {
            var data = GameService.GetGameDetails(gameId);
            return Ok(data);
        }
        [HttpGet("getGamePlayersStats/{gameId}")]
        public ActionResult GetGamePlayersStats(int gameId)
        {
            var data = GameService.GetGamePlayersStats(gameId);
            return Ok(data);
        }
        [HttpGet("getGameStatistics/{gameId}")]
        public ActionResult GetGameStatistics(int gameId)
        {
            var data = GameService.GetGamePlayersStats(gameId);
            return Ok(data);
        }
        [HttpGet("getGamePlayerStatistics")]
        public ActionResult GetGamePlayerStatistics(int playerId, int gameId)
        {
            var data = GameService.GetGamePlayerStatistics(playerId, gameId);
            return Ok(data);
        }
        [HttpPost("saveGamePlayerStatistics")]
        public ActionResult SaveGamePlayerStatistics(GamePlayerStatisticsVM data)
        {
            GameService.SaveGamePlayerStatistics(data);
            return Ok(true);
        }
    }
}
