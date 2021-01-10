using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Team
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        private readonly ITeamService TeamService;
        private readonly IStatsService StatsService;
        public TeamController(IPlayerService playerService, ITeamService teamService, IStatsService statsService)
        {
            this.PlayerService = playerService;
            this.TeamService = teamService;
            this.StatsService = statsService;
        }
        [HttpGet("getPlayersList")]
        public ActionResult GetPlayersList()
        {
            var data = PlayerService.GetTeamPlayers();
            return Ok(data);
        }
        [HttpGet("getFirstLineupPlayers")]
        public ActionResult GetFirstLineupPlayers()
        {
            var data = PlayerService.GetFirstLineupPlayers();
            return Ok(data);
        }
        [HttpGet("getPlayerDetails/{playerId}")]
        public ActionResult GetPlayerDetails(int playerId)
        {
            var data = PlayerService.SetPlayerDetails(playerId);
            return Ok(data);
        }
        [HttpPost("editPlayer")]
        public ActionResult EditPlayer(EditPlayerVM model)
        {
            var data = PlayerService.EditPlayer(model);
            return Ok(data);
        }
        [HttpGet("getPlayersByPosition/{position}")]
        public ActionResult GetPlayersByPosition(int position)
        {
            List<SelectModelBinder<int>> players = TeamService.GetPlayersByPosition(position);
            return Ok(players);
        }
        [HttpGet("getFirstLineupPlayer/{position}")]
        public ActionResult GetFirstLineupPlayer(int position)
        {
            var player = TeamService.GetFirstLineupPlayerByPosition(position);
            return Ok(player);
        }
        [HttpPost("saveFirstLineup")]
        public ActionResult SaveFirstLineup(FirstLineupVM model)
        {
            TeamService.SaveFirstLineup(model);
            return Ok(true);
        }
        [HttpGet("getDataToPlayerDetailsChart/{playerId}")]
        public ActionResult GetDataToPlayerDetailsChart(int playerId)
        {
            var data = TeamService.GetDataToPlayerDetailsChart(playerId);
            return Ok(data);
        }
        [HttpGet("getPlayerLastGamesStats/{playerId}")]
        public ActionResult GetPlayerLastGameStats(int playerId)
        {
            var data = TeamService.GetPlayerLastGameStats(playerId);
            return Ok(data);
        }
        [HttpGet("getEditForm")]
        public ActionResult GetFirstLineupIds()
        {
            var data = TeamService.GetFirstLineupIds();
            return Ok(data);
        }
        [HttpGet("getPlayerInjuries/{playerId}")]
        public ActionResult GetPlayerInjuries(int playerId)
        {
            var data = PlayerService.GetPlayerInjuries(playerId);
            return Ok(data);
        }
        [HttpPost("addPlayerInjury")]
        public ActionResult AddPlayerInjury(AddPlayerInjuryVM data)
        {
            PlayerService.AddPlayerInjury(data);
            return Ok(true);
        }
        [HttpGet("getPlayerAvgs/{playerId}")]
        public ActionResult GetPlayerAvgs(int playerId)
        {
            var data = TeamService.GetPlayerAvgs(playerId);
            return Ok(data);
        }
        [HttpGet("getPlayerRecords/{playerId}")]
        public ActionResult GetPlayerRecords(int playerId)
        {
            var data = TeamService.GetPlayerRecords(playerId);
            return Ok(data);
        }
        [HttpGet("getAllPlayerGames/{playerId}")]
        public ActionResult GetAllPlayerGames(int playerId)
        {
            var data = TeamService.GetAllPlayerGames(playerId);
            return Ok(data);
        }
        [HttpGet("getDataToSpiderWeb/{playerId}")]
        public ActionResult GetDataToSpiderWeb(int playerId)
        {
            var data = TeamService.GetDataToSpiderWeb(playerId);
            return Ok(data);
        }
        [HttpGet("getPlayerCondition/{playerId}")]
        public ActionResult GetPlayerCondition(int playerId)
        {
            var data = StatsService.GetPlayerCondition(playerId);
            return Ok(data);
        }
        [HttpGet("getSubstitutePlayers")]
        public ActionResult GetSubstitutePlayers()
        {
            var data = PlayerService.GetSubstitutePlayers();
            return Ok(data);
        }
    }
}
