using BasketUnit.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Controllers.Schedules
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public SchedulesController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getActivities")]
        public ActionResult GetActivities()
        {
            var data = PlayerService.GetActivities();
            return Ok(data);
        }
        [HttpGet("getExcercisesToLookup")]
        public ActionResult GetExcercisesToLookup()
        {
            var data = PlayerService.GetExcercisesToLookup();
            return Ok(data);
        }
        [HttpGet("getTeamsToLookup")]
        public ActionResult etTeamsToLookup()
        {
            var data = PlayerService.GetTeamsToLookup();
            return Ok(data);
        }
    }
}
