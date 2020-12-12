using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.ViewModels;
using BasketUnit.WebAPI.Utils;
using BasketUnit.WebAPI.Enums;

namespace BasketUnit.WebAPI.Controllers.Administration.HumanResources
{
    [Route("api/administration/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        private readonly ICoachService CoachService;
        private readonly IRefereeService RefereeService;
        private readonly ITeamService TeamService;
        private readonly INationalityService NationalityService;
        public HumanResourcesController(IPlayerService playerService, ICoachService coachService, IRefereeService refereeService, ITeamService teamService, INationalityService nationalityService)
        {
            this.PlayerService = playerService;
            this.CoachService = coachService;
            this.RefereeService = refereeService;
            this.TeamService = teamService;
            this.NationalityService = nationalityService;
            
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
            var data = CoachService.GetCoaches();
            return Ok(data);
        }
        [HttpGet("getReferees")]
        public ActionResult GetReferees()
        {
            var data = RefereeService.GetReferees();
            return Ok(data);
        }
        [HttpGet("getTeamsToLookup")]
        public ActionResult GetTeamsToLookup()
        {
            var data = TeamService.GetTeamsToLookup();
            return Ok(data);
        }
        [HttpGet("getPositionsToLookup")]
        public ActionResult GetPositionsToLookup()
        {
            List<EnumModelBinder> positions = EnumHelpers.GetEnumBinderList<Position>();
            return Ok(positions);
        }
        [HttpGet("getPlayerDetails/{playerId}")]
        public ActionResult GetPlayerDetails(int playerId)
        {
            var data = PlayerService.SetPlayerDetails(playerId);
            return Ok(data);
        }
        [HttpGet("getCoachDetails/{coachId}")]
        public ActionResult GetCoachDetails(int coachId)
        {
            var data = CoachService.SetCoachDetails(coachId);
            return Ok(data);
        }
        [HttpGet("getRefereeDetails/{refereeId}")]
        public ActionResult GetRefereeDetails(int refereeId)
        {
            var data = RefereeService.SetRefereeDetails(refereeId);
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
            var data = CoachService.EditCoach(model);
            return Ok(data);
        }
        [HttpPost("editReferee")]
        public ActionResult EditReferee(EditRefereeVM model)
        {
            var data = RefereeService.EditReferee(model);
            return Ok(data);
        }
        //[HttpGet("getPlayerDataToDetails")]
        //public ActionResult GetPlayerDataToDetails(int playerId)
        //{
        //    var data = PlayerService.GetPlayerDataToDetails(playerId);
        //    return Ok(data);
        //}
        //[HttpGet("getLastPlayerStatistics")]
        //public ActionResult GetLastPlayerStatistics(int playerId)
        //{
        //    var data = PlayerService.GetLastPlayerStatistics(playerId);
        //    return Ok(data);
        //}
        //[HttpGet("getAvarageStatsToChart")]
        //public ActionResult GetAvarageStatsToChart(int playerId)
        //{
        //    var data = PlayerService.GetAvarageStatsToChart(playerId);
        //    return Ok(data);
        //}
        [HttpPost("addPlayer")]
        public ActionResult AddPlayer(AddPlayerVM model)
        {
            var data = PlayerService.AddPlayer(model);
            return Ok(data);
        }
        [HttpPost("addCoach")]
        public ActionResult AddCoach(AddCoachVM model)
        {
            var data = CoachService.AddCoach(model);
            return Ok(data);
        }
        [HttpPost("addReferee")]
        public ActionResult AddReferee(AddRefereeVM model)
        {
            var data = RefereeService.AddReferee(model);
            return Ok(data);
        }
        [HttpPost("deletePlayer/{playerId}")]
        public ActionResult DeletePlayer(int playerId)
        {
            PlayerService.DeletePlayer(playerId);
            return Ok(true);
        }
        [HttpPost("deleteCoach/{coachId}")]
        public ActionResult DeleteCoach(int coachId)
        {
            CoachService.DeleteCoach(coachId);
            return Ok(true);
        }
        [HttpPost("deleteReferee/{refereeId}")]
        public ActionResult DeleteReferee(int refereeId)
        {
            RefereeService.DeleteReferee(refereeId);
            return Ok(true);
        }
        [HttpGet("getNationalities")]
        public ActionResult GetNationalities()
        {
            var data = NationalityService.GetNationalitiesToLookup();
            return Ok(data);
        }
        [HttpGet("getNationalitiesList")]
        public ActionResult GetNationalitiesList()
        {
            var data = NationalityService.GetNationalitiesList();
            return Ok(data);
        }
        [HttpGet("getNationalityDetails/{nationalityId}")]
        public ActionResult GetNationalityDetails(int nationalityId)
        {
            var data = NationalityService.GetNationalityDetails(nationalityId);
            return Ok(data);
        }
        [HttpPost("addNationality")]
        public ActionResult AddNationality(AddNationalityVM model)
        {
            NationalityService.AddNationality(model);
            return Ok(true);
        }
        [HttpPost("editNationality")]
        public ActionResult EditNationality(EditNationalityVM model)
        {
            NationalityService.EditNationality(model);
            return Ok(true);
        }
        [HttpPost("deleteNationality/{nationalityId}")]
        public ActionResult DeleteNationality(int nationalityId)
        {
            NationalityService.DeleteNationality(nationalityId);
            return Ok(true);
        }
    }
}
