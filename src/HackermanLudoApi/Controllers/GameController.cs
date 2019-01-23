using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HackermanLudoApi.Models;
using GameEngine;

namespace HackermanLudoApi.Controllers
{
    [Route("api/ludo/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        ////// GET: api/ludo/Game
        //[HttpGet]
        //public List<Game> Get()
        //{
        //    return FiaService.GettingGames();
        //}

        // GET: api/Ludo/Game/games
        
        [HttpGet("game")]
        public List<string> Get(string getgames)
        {
            return GamSesssion.GetGame();
        }


        // POST: api/Ludo/game/CreateGame
        [HttpPost("creategame")]
        public string[] NewGame(string[] gameInfo)
        {
            int players = int.Parse(gameInfo[0]);
            string gameName = gameInfo[1];
            return GamSesssion.NewGame(players, gameName);
           
        }

        //GET: api/ludo/game/gameInfo

        [HttpGet("gameInfo")]
        public List<string> Get()
        {
            return GamSesssion.GameInfo();
        }

        // Put: api/ludo/game/updatepieceposition

        [HttpPut("updatepieceposition/{pieceNr}")]
        public string[] MovePiece(int pieceNr)
        {
            return GamSesssion.MovePiece(pieceNr);


    }
}
