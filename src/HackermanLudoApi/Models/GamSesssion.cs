using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameEngine;
using Newtonsoft.Json;


namespace HackermanLudoApi.Models
{
    public class GamSesssion
    {

        static public List<LudoEngine> GameList = new List<LudoEngine>();
        static public LudoEngine game;


        static public void SaveGame(LudoEngine gameToSave)
        {
            bool found = false;
            ShowSavedGames();
            for (int i = 0; i < GameList.Count && !found; i++)
            {
                if (GameList[i].GameName == gameToSave.GameName)
                {
                    GameList.RemoveAt(i);
                    found = true;
                }
            }
            GameList.Add(gameToSave);
            var json = JsonConvert.SerializeObject(GameList.ToArray());
            File.WriteAllText(@"c:/windows/temp/ludo.json", json);
        }


        static public string[] LoadSavedGame(string gameName)
        {
            foreach (var item in GameList)
            {
                if (item.GameName == gameName)
                {
                    game = item;
                }
            }
            string[] returnString = new string[2];
            return returnString = game.NextTurn();
        }


        static public List<LudoEngine> ShowSavedGames()
        {
            if (File.Exists(@"c:/windows/temp/ludo.json"))
            {
                using (var r = new StreamReader(@"c:/windows/temp/ludo.json"))
                {
                    var json = r.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<List<LudoEngine>>(json);
                    GameList = list;
                }
            }
            return GameList;
        }
        static public List<string> GetGame()
        {
            var gameList = GamSesssion.ShowSavedGames();
            var returnList = new List<string>();
            foreach (var item in gameList)
            {
                returnList.Add(item.GameName);
            }
            return returnList;
        }


        static public string[] NewGame(int numbersOfPlayers, string gameName)
        {
            game = new LudoEngine(numbersOfPlayers, gameName);
            string[] returnString = new string[2];
            return returnString = game.NextTurn();

        }

        static public string[] MovePiece(int pieceNr)
        {
            return game.MovePiece(pieceNr - 1);
        }


        static public List<string> GameInfo()
        {
            List<string> returnList = new List<string>();
            game.NextTurn();

            foreach (var item in game.PlayersList[game.ActivePlayer].Pieces)
            {
                if (item.InNest)
                {
                    returnList.Add(item.PlayerColor + " " + item.PieceName + " " + " is in nest.");

                }
                else
                {
                    returnList.Add(item.PlayerColor + " players piece: " + item.PieceName + " has moved: " + item.Movement);
                }
            }


            foreach (var item in game.TileList)
            {
                if (item.PieceList.Count > 0)
                {

                    foreach (var piece in item.PieceList)
                    {
                        returnList.Add("Player " + piece.PlayerColor + " PieceNr: " + piece.PieceName + " is on tile nr: " + item.TilePosition);
                    }
                }
            }
            returnList.Add(game.LastDiceThrow + "," + game.PlayersList[game.ActivePlayer].Color);
            return returnList;
        }
    }
}
