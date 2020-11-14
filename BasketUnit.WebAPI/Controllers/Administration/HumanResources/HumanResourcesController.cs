using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasketUnit.WebAPI.Services;

namespace BasketUnit.WebAPI.Controllers.Administration.HumanResources
{
    [Route("api/administration/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public HumanResourcesController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getPlayers")]
        public ActionResult GetPlayers()
        {
            var data = PlayerService.GetPlayers();
            return Ok(data);
        }
        [HttpGet("GetCoaches")]
        public ActionResult GetCoaches()
        {
            var data = PlayerService.GetCoaches();
            return Ok(data);
        }
        [HttpGet("getReferees")]
        public ActionResult GetReferees()
        {
            var data = PlayerService.GetReferees();
            return Ok(data);
        }
        [HttpGet("getTeamsToLookup")]
        public ActionResult GetTeamsToLookup()
        {
            var data = PlayerService.GetTeamsToLookup();
            return Ok(data);
        }
        [HttpGet("getPositionsToLookup")]
        public ActionResult GetPositionsToLookup()
        {
            var data = PlayerService.GetPositionsToLookup();
            return Ok(data);
        }
        [HttpGet("getPlayerDetails")]
        public ActionResult GetPlayerDetails(int playerId)
        {
            var data = PlayerService.GetPlayerDetails(playerId);
            return Ok(data);
        }
        [HttpGet("getCoachDetails")]
        public ActionResult GetCoachDetails(int coachId)
        {
            var data = PlayerService.GetCoachDetails(coachId);
            return Ok(data);
        }
        [HttpGet("getRefereeDetails")]
        public ActionResult GetRefereeDetails(int refereeId)
        {
            var data = PlayerService.GetRefereeDetails(refereeId);
            return Ok(data);
        }
        [HttpPost("editPlayer")]
        public ActionResult EditPlayer(EditPlayerVM model)
        {
            var data = PlayerService.EditPlayer(model);
            return Ok(data);
        }
        [HttpPost("editCoach")]
        public ActionResult EditCoach(EditCoachVM model)
        {
            var data = PlayerService.EditCoach(model);
            return Ok(data);
        }
        [HttpPost("editReferee")]
        public ActionResult EditReferee(EditRefereeVM model)
        {
            var data = PlayerService.EditReferee(model);
            return Ok(data);
        }
        [HttpGet("getPlayerDataToDetails")]
        public ActionResult GetPlayerDataToDetails(int playerId)
        {
            var data = PlayerService.GetPlayerDataToDetails(playerId);
            return Ok(data);
        }
        [HttpGet("getLastPlayerStatistics")]
        public ActionResult GetLastPlayerStatistics(int playerId)
        {
            var data = PlayerService.GetLastPlayerStatistics(playerId);
            return Ok(data);
        }
        [HttpGet("getAvarageStatsToChart")]
        public ActionResult GetAvarageStatsToChart(int playerId)
        {
            var data = PlayerService.GetAvarageStatsToChart(playerId);
            return Ok(data);
        }
        [HttpPost("addPlayer")]
        public ActionResult AddPlayer(AddPlayerVM model)
        {
            var data = PlayerService.AddPlayer(model);
            return Ok(data);
        }
        [HttpPost("addCoach")]
        public ActionResult AddCoach(AddCoachVM model)
        {
            var data = PlayerService.AddCoach(model);
            return Ok(data);
        }
        [HttpPost("addReferee")]
        public ActionResult AddReferee(AddRefereeVM model)
        {
            var data = PlayerService.AddReferee(model);
            return Ok(data);
        }
    }
}
