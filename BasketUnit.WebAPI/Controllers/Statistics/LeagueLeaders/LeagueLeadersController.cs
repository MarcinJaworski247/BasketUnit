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
        private readonly IPlayerService PlayerService;
        public LeagueLeadersController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        //[HttpGet("getPointsLeaders")]
        //public ActionResult GetPointsLeaders()
        //{
        //    var data = PlayerService.GetPointsLeaders();
        //    return Ok(data);
        //}
        //[HttpGet("getAssistsLeaders")]
        //public ActionResult GetAssistsLeaders()
        //{
        //    var data = PlayerService.GetAssistsLeaders();
        //    return Ok(data);
        //}
        //[HttpGet("getReboundsLeaders")]
        //public ActionResult GetReboundsLeaders()
        //{
        //    var data = PlayerService.GetReboundsLeaders();
        //    return Ok(data);
        //}
        //[HttpGet("getBlocksLeaders")]
        //public ActionResult GetBlocksLeaders()
        //{
        //    var data = PlayerService.GetBlocksLeaders();
        //    return Ok(data);
        //}
        //[HttpGet("getStealsLeaders")]
        //public ActionResult GetStealsLeaders()
        //{
        //    var data = PlayerService.GetStealsLeaders();
        //    return Ok(data);
        //}
    }
}
