using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Controllers.Statistics
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatsService StatsService;
        private readonly ITeamService TeamService;
        public StatisticsController(IStatsService statsService, ITeamService teamService)
        {
            this.StatsService = statsService;
            this.TeamService = teamService;
        }
        [HttpGet("getTeamForm")]
        public ActionResult GetTeamForm()
        {
            var data = TeamService.GetTeamForm();
            return Ok(data);
        }
        [HttpGet("getTeamAverages")]
        public ActionResult GetTeamAverages()
        {
            var data = StatsService.GetTeamAverages();
            return Ok(data);
        }
        [HttpGet("getTeamScoreAndLosePoints")]
        public ActionResult GetTeamScoreAndLosePoints()
        {
            var data = StatsService.GetTeamScoreAndLosePoints();
            return Ok(data);
        }
        //[HttpGet("predictGameResult/{gameId}")]
        //public ActionResult PredictGameResult(int gameId)
        //{
        //    var result = StatsService.PredictGameResult();
        //    return Ok(result);
        //}
        [HttpGet("getFutureGames")]
        public ActionResult GetFutureGames()
        {
            var data = TeamService.GetFutureGamesWithPrediction();
            return Ok(data);
        }
    }
}
