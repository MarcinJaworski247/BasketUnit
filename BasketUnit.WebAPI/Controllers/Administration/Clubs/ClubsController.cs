using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasketUnit.WebAPI.Services;

namespace BasketUnit.WebAPI.Controllers.Administration.Clubs
{
    [Route("api/administration/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly ITeamService TeamService;
        public ClubsController(ITeamService teamService)
        {
            this.TeamService = teamService;
        }
        [HttpGet("getCoachesToLookup")]
        public ActionResult GetCoachesToLookup()
        {
            var data = TeamService.GetCoachesToLookup();
            return Ok(data);
        }
        [HttpGet("getArenasToLookup")]
        public ActionResult GetArenasToLookup()
        {
            var data = TeamService.GetArenasToLookup();
            return Ok(data);
        }
        [HttpPost("addTeam")]
        public ActionResult AddTeam(AddTeamVM model)
        {
            var data = TeamService.AddTeam(model);
            return Ok(data);
        }
        [HttpGet("setTeamDetails")]
        public ActionResult SetTeamDetails(int teamId)
        {
            var data = TeamService.SetTeamDetails(teamId);
            return Ok(data);
        }
        [HttpPost("editTeam")]
        public ActionResult EditTeam(EditTeamVM model)
        {
            var data = TeamService.EditTeam(model);
            return Ok(data);
        }
        [HttpGet("getTeams")]
        public ActionResult GetTeams()
        {
            var data = TeamService.GetTeams();
            return Ok(data);
        }
        [HttpGet("getArenas")]
        public ActionResult GetArenas()
        {
            var data = TeamService.GetArenas();
            return Ok(data);
        }
        [HttpPost("editArena")]
        public ActionResult EditArena(EditArenaVM model)
        {
            var data = TeamService.EditArena(model);
            return Ok(data);
        }
        [HttpGet("setArenaDetails")]
        public ActionResult SetArenaDetails(int arenaId)
        {
            var data = TeamService.SetArenaDetails(arenaId);
            return Ok(data);
        }
    }
}
