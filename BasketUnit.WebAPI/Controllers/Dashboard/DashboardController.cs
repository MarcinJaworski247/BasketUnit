using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITeamService TeamService;
        public DashboardController(ITeamService teamService)
        {
            this.TeamService = teamService;
        }
        [HttpGet("getLastGames")]
        public ActionResult GetLastGames()
        {
            var data = TeamService.GetLastGamesToDashboard();
            return Ok(data);
        }
        [HttpGet("getFutureGames")]
        public ActionResult GetFutureGames()
        {
            var data = TeamService.GetFutureGamesToDashboard();
            return Ok(data);
        }
        [HttpGet("getInjuredPlayers")]
        public ActionResult GetInjuredPlayers()
        {
            var data = TeamService.GetInjuredPlayersToDashboard();
            return Ok(data);
        }
        [HttpGet("getFutureWorkouts")]
        public ActionResult GetFutureWorkouts()
        {
            var data = TeamService.GetFutureWorkouts();
            return Ok(data);
        }
    }
}
