using BasketUnit.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BasketUnit.WebAPI.ViewModels;

namespace BasketUnit.WebAPI.Controllers.Schedules
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ITeamScheduleService TeamScheduleService;
        private readonly IGameService GameService;
        private readonly IWorkoutService WorkoutService;
        private readonly ITeamService TeamService;
        private readonly IRefereeService RefereeService;
        private readonly IArenaService ArenaService;
        private readonly ITeamScheduleActivityService TeamScheduleActivityService;
        public SchedulesController(ITeamScheduleService teamScheduleService, IGameService gameService, IWorkoutService workoutService, ITeamService teamService, IRefereeService refereeService, IArenaService arenaService, ITeamScheduleActivityService teamScheduleActivityService)
        {
            this.TeamScheduleService = teamScheduleService;
            this.GameService = gameService;
            this.WorkoutService = workoutService;
            this.TeamService = teamService;
            this.RefereeService = refereeService;
            this.ArenaService = arenaService;
            this.TeamScheduleActivityService = teamScheduleActivityService;
        }
        [HttpGet("getActivitiesToShow")]
        public ActionResult GetActivities()
        {
            var data = TeamScheduleService.GetActivities();
            return Ok(data);
        }
        [HttpGet("getExcercisesToLookup")]
        public ActionResult GetExcercisesToLookup()
        {
            var data = WorkoutService.GetWorkoutsToLookup();
            return Ok(data);
        }
        [HttpGet("getTeamsToLookup")]
        public ActionResult GetTeamsToLookup()
        {
            var data = TeamService.GetTeamsToLookup();
            return Ok(data);
        }
        [HttpGet("getArenasToLookup")]
        public ActionResult GetArenasToLookup()
        {
            var data = ArenaService.GetArenasToLookup();
            return Ok(data);
        }
        [HttpGet("getRefereesToLookup")]
        public ActionResult GetRefereesToLookup()
        {
            var data = RefereeService.GetRefereesToLookup();
            return Ok(data);
        }
        [HttpPost("addGame")]
        public ActionResult AddGame(AddGameVM model)
        {
            GameService.AddGame(model);
            return Ok(true);
        }
        [HttpPost("addWorkout")]
        public ActionResult AddWorkout(AddWorkoutScheduleVM model)
        {
            TeamScheduleActivityService.AddWorkout(model);
            return Ok(true);
        }
    }
}
