using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Team
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public TeamController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getPlayersList")]
        public ActionResult GetPlayersList()
        {
            var data = PlayerService.GetPlayersList();
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
            var data = PlayerService.GetPlayerDetails(playerId);
            return Ok(data);
        }
        [HttpPost("editPlayer")]
        public ActionResult EditPlayer(EditPlayerVM model)
        {
            var data = PlayerService.EditPlayer(model);
            return Ok(data);
        }
    }
}
