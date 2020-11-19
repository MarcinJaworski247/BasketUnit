using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketUnit.WebAPI.Services;
using BasketUnit.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BasketUnit.WebAPI.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService GameService;
        public GameController(IGameService gameService)
        {
            this.GameService = gameService;
        }
        //[HttpGet("getGames")]
        //public ActionResult GetGames()
        //{
        //    var data = GameService.GetGames();
        //    return Ok(data);
        //}
        //[HttpGet("getGamesToLookup")]
        //public ActionResult GetGamesToLookup()
        //{
        //    var data = GameService.GetGamesToLookup();
        //    return Ok(data);
        //}
        //[HttpPost("addGame")]
        //public ActionResult AddGame(AddGameVM model)
        //{
        //    var data = GameService.AddGame(model);
        //    return Ok(data);
        //}
        //[HttpPost("editGame")]
        //public ActionResult EditGame(EditGameVM model)
        //{
        //    var data = GameService.EditGame(model);
        //    return Ok(data);
        //}
        //[HttpGet("getGameDetails")]
        //public ActionResult GetExcersiseDetails(int gameId)
        //{
        //    var data = GameService.SetGameDetails(gameId);
        //    return Ok(data);
        //}
        //[HttpPost("deleteGame")]
        //public ActionResult DeleteGame(int gameId)
        //{
        //    GameService.DeleteGame(gameId);
        //    return Ok(true);
        //}
    }
}
