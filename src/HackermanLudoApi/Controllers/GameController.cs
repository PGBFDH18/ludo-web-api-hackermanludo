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
        [HttpGet("{id}")]
        public List<Game> Get(int id)
        {
            return FiaService.GettingGame(id);
        }

        // GET: api/Ludo/Game/games

        [HttpGet("games")]
        public List<string> Get(string getgames)
        {
            return GamSesssion.GetGame();
        }


        // POST: api/Ludo/game/CreateGame
        [HttpPost("creategame")]
        public string[] NewGame(string[] gameInfo)
        {
            int choice = int.Parse(gameInfo[2]);
            if (choice == 1)
            {
                int players = int.Parse(gameInfo[0]);
                string gameName = gameInfo[1];
                return GamSesssion.NewGame(players, gameName);
            }
            return GamSesssion.GetGame().ToArray();
        }

        // POST: api/Ludo/game/LoadGame
        [HttpPost("LoadGame/{gameName}")]
        public string[] LoadGame(string gameName)
        {

            return GamSesssion.LoadSavedGame(gameName);

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

        // POST: api/Ludo/game/LoadGame
        [HttpPost("SaveGame/")]
        public string LoadGame()
        {

            GamSesssion.SaveGame(GamSesssion.game);
            return $"Game {GamSesssion.game.GameName} is saved";
        }

    }
}
