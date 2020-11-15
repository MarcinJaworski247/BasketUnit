using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Workouts
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService WorkoutService;
        private readonly IWorkoutTypeService WorkoutTypeService;
        public WorkoutsController(IWorkoutService workoutService, IWorkoutTypeService workoutTypeService)
        {
            this.WorkoutService = workoutService;
            this.WorkoutTypeService = workoutTypeService;
        }
        [HttpGet("getExcersises")]
        public ActionResult GetExcersises()
        {
            var data = WorkoutService.GetWorkouts();
            return Ok(data);
        }
        [HttpGet("getWorkoutTypesToLookup")]
        public ActionResult GetWorkoutTypesToLookup()
        {
            var data = WorkoutTypeService.GetWorkoutTypesToLookup();
            return Ok(data);
        }
        [HttpPost("addExcersise")]
        public ActionResult AddExcersise(AddWorkoutVM model)
        {
            var data = WorkoutService.AddWorkout(model);
            return Ok(data);
        }
        [HttpPost("editExcersise")]
        public ActionResult EditExcersise(EditWorkoutVM model)
        {
            var data = WorkoutService.EditWorkout(model);
            return Ok(data);
        }
        [HttpGet("getExcersiseDetails")]
        public ActionResult GetExcersiseDetails(int workoutId)
        {
            var data = WorkoutService.SetWorkoutDetails(workoutId);
            return Ok(data);
        }
        [HttpGet("getWorkoutTypes")]
        public ActionResult GetWorkoutTypes()
        {
            var data = WorkoutTypeService.GetWorkoutTypes();
            return Ok(data);
        }
        [HttpPost("addWorkoutType")]
        public ActionResult AddWorkoutType(AddWorkoutTypeVM model)
        {
            var data = WorkoutTypeService.AddWorkoutType(model);
            return Ok(data);
        }
        [HttpPost("editWorkoutType")]
        public ActionResult EditWorkoutType(EditWorkoutTypeVM model)
        {
            var data = WorkoutTypeService.EditWorkoutType(model);
            return Ok(data);
        }
        [HttpGet("GetWorkoutTypeDetails")]
        public ActionResult GetWorkoutTypeDetails(int workoutTypeId)
        {
            var data = WorkoutTypeService.SetWorkoutTypeDetails(workoutTypeId);
            return Ok(data);
        }
        [HttpPost("deleteWorkout")]
        public ActionResult DeleteWorkout(int workoutId)
        {
            WorkoutService.DeleteWorkout(workoutId);
            return Ok(true);
        }
        [HttpPost("deleteWorkoutType")]
        public ActionResult DeleteWorkoutType(int workoutTypeId)
        {
            WorkoutTypeService.DeleteWorkoutType(workoutTypeId);
            return Ok(true);
        }
    }
}
