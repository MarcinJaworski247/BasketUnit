using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Statistics.LeagueLeaders
{
    [Route("api/statistics/[controller]")]
    [ApiController]
    public class LeagueLeadersController : ControllerBase
    {
        private readonly IStatsService StatsService;
        public LeagueLeadersController(IStatsService statsService)
        {
            this.StatsService = statsService;
        }
        [HttpGet("getLeadersToWidget")]
        public ActionResult GetLeadersToWidget()
        {
            var data = StatsService.GetLeadersToWidget();
            return Ok(data);
        }
    }
}
