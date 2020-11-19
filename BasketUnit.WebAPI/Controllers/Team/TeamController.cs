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
        public TeamController(IPlayerService playerService, ITeamService teamService)
        {
            this.PlayerService = playerService;
            this.TeamService = teamService;
        }
        [HttpGet("getPlayersList")]
        public ActionResult GetPlayersList()
        {
            var data = PlayerService.GetPlayers();
            return Ok(data);
        }
        [HttpGet("GetFirstLineupPlayers")]
        public ActionResult GetFirstLineupPlayers()
        {
            var data = PlayerService.GetFirstLineupPlayers();
            return Ok(data);
        }
        [HttpGet("getPlayerDetails")]
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
        [HttpGet("getPlayersByPosition")]
        public ActionResult GetPlayersByPosition(int position)
        {
            List<SelectModelBinder<int>> players = TeamService.GetPlayersByPosition(position);
            return Ok(players);
        }
        [HttpGet("getFirstLineupPlayer")]
        public ActionResult GetFirstLineupPlayer(int position)
        {
            var player = TeamService.GetFirstLineupPlayerByPosition(position);
            return Ok(player);
        }
        [HttpPost("saveFirstLineup")]
        public ActionResult SaveFirstLineup(int pointGuardId, int shootingGuardId, int smallForwardId, int powerForwardId, int centerId)
        {
            TeamService.SaveFirstLineup(pointGuardId, shootingGuardId, smallForwardId, powerForwardId, centerId);
            return Ok(true);
        }
    }
}
