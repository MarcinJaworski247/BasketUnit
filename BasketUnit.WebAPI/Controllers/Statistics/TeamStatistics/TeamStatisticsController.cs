﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Statistics.TeamStatistics
{
    [Route("api/statistics/[controller]")]
    [ApiController]
    public class TeamStatisticsController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public TeamStatisticsController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getPlayers")]
        public ActionResult GetPlayers()
        {
            var data = PlayerService.GetPlayers();
            return Ok(data);
        }
    }
}
