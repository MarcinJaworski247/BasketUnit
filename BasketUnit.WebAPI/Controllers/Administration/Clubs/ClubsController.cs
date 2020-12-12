using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.ViewModels;

namespace BasketUnit.WebAPI.Controllers.Administration.Clubs
{
    [Route("api/administration/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly ITeamService TeamService;
        private readonly ICoachService CoachService;
        private readonly IArenaService ArenaService;
        private readonly ICollegeService CollegeService;
        public ClubsController(ITeamService teamService, ICoachService coachService, IArenaService arenaService, ICollegeService collegeService)
        {
            this.TeamService = teamService;
            this.CoachService = coachService;
            this.ArenaService = arenaService;
            this.CollegeService = collegeService;
        }
        [HttpGet("getCoachesToLookup")]
        public ActionResult GetCoachesToLookup()
        {
            List<SelectModelBinder<int>> data = CoachService.GetCoachesToLookup();
            return Ok(data);
        }
        [HttpGet("getArenasToLookup")]
        public ActionResult GetArenasToLookup()
        {
            List<SelectModelBinder<int>> data = ArenaService.GetArenasToLookup();
            return Ok(data);
        }
        [HttpPost("addTeam")]
        public ActionResult AddTeam(AddTeamVM model)
        {
            var team = TeamService.AddTeam(model);
            return Ok(team);
        }
        [HttpGet("setTeamDetails/{teamId}")]
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
            var data = ArenaService.GetArenas();
            return Ok(data);
        }
        [HttpPost("editArena")]
        public ActionResult EditArena(EditArenaVM model)
        {
            var data = ArenaService.EditArena(model);
            return Ok(data);
        }
        [HttpGet("setArenaDetails/{arenaId}")]
        public ActionResult SetArenaDetails(int arenaId)
        {
            var data = ArenaService.SetArenaDetails(arenaId);
            return Ok(data);
        }
        [HttpPost("addArena")]
        public ActionResult AddArena(AddArenaVM model)
        {
            var data = ArenaService.AddArena(model);
            return Ok(data);
        }
        [HttpPost("deleteArena/{arenaId}")]
        public ActionResult DeleteArena(int arenaId)
        {
            ArenaService.DeleteArena(arenaId);
            return Ok(true);
        }
        [HttpPost("deleteTeam/{teamId}")]
        public ActionResult DeleteTeam(int teamId)
        {
            TeamService.DeleteTeam(teamId);
            return Ok(true);
        }
        [HttpGet("getCollegesList")]
        public ActionResult GetCollegesList()
        {
            var data = CollegeService.GetCollegesList();
            return Ok(data);
        }
        [HttpGet("getCollegesToLookup")]
        public ActionResult GetCollegesToLookup()
        {
            List<SelectModelBinder<int>> data = CollegeService.GetCollegesToLookup();
            return Ok(data);
        }
        [HttpGet("getCollegeDetails/{collegeId}")]
        public ActionResult GetCollegeDetails(int collegeId)
        {
            var data = CollegeService.GetCollegeDetails(collegeId);
            return Ok(data);
        }
        [HttpPost("addCollege")]
        public ActionResult AddCollege(AddCollegeVM model)
        {
            CollegeService.AddCollege(model);
            return Ok(true);
        }
        [HttpPost("deleteCollege/{collegeId}")]
        public ActionResult DeleteCollege(int collegeId)
        {
            CollegeService.DeleteCollege(collegeId);
            return Ok(true);
        }
        [HttpPost("editCollege")]
        public ActionResult EditCollege(EditCollegeVM model)
        {
            CollegeService.EditCollege(model);
            return Ok(true);
        }
    }
}
