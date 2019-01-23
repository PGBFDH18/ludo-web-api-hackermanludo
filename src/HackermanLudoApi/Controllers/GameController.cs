using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HackermanLudoApi.Models;

namespace HackermanLudoApi.Controllers
{
    [Route("api/ludo/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        //// GET: api/Game
        [HttpGet]
        public List<Game> Get()
        {
            return FiaService.GettingGames();
        }

        // GET: api/Game/games
        
        [HttpGet("game")]
        public List<string> Get(string getgames)
        {
            var gameList = GamSesssion.LoadGame();
            var returnList = new List<string>();
            foreach (var item in gameList)
            {
                returnList.Add(item.GameName);
            }
            return returnList;
        }


    }
}
