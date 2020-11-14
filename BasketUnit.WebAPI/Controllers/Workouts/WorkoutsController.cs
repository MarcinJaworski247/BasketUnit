using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Workouts
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IPlayerService PlayerService;
        public WorkoutsController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }
        [HttpGet("getExcersises")]
        public ActionResult GetExcersises()
        {
            var data = PlayerService.GetExcersises();
            return Ok(data);
        }
        [HttpGet("getWorkoutTypesToLookup")]
        public ActionResult GetWorkoutTypesToLookup()
        {
            var data = PlayerService.GetWorkoutTypesToLookup();
            return Ok(data);
        }
        [HttpPost("addExcersise")]
        public ActionResult AddExcersise(AddExcersiseVM model)
        {
            var data = PlayerService.AddExcersise(model);
            return Ok(data);
        }
        [HttpPost("editExcersise")]
        public ActionResult EditExcersise(EditExcersiseVM model)
        {
            var data = PlayerService.EditExcersise(model);
            return Ok(data);
        }
        [HttpGet("getExcersiseDetails")]
        public ActionResult GetExcersiseDetails(ExcersiseDetailsVM model)
        {
            var data = PlayerService.GetExcersiseDetails(model);
            return Ok(data);
        }
        [HttpGet("getWorkoutTypes")]
        public ActionResult GetWorkoutTypes()
        {
            var data = PlayerService.GetWorkoutTypes();
            return Ok(data);
        }
        [HttpPost("addWorkoutType")]
        public ActionResult AddWorkoutType(AddWorkoutTypeVM model)
        {
            var data = PlayerService.AddWorkoutType(model);
            return Ok(data);
        }
        [HttpPost("editWorkoutType")]
        public ActionResult EditWorkoutType(EditWorkoutTypeVM model)
        {
            var data = PlayerService.EditWorkoutType(model);
            return Ok(data);
        }
        [HttpGet("GetWorkoutTypeDetails")]
        public ActionResult GetWorkoutTypeDetails(int workoutTypeId)
        {
            var data = PlayerService.GetWorkoutTypeDetails(workoutTypeId);
            return Ok(data);
        }
    }
}
