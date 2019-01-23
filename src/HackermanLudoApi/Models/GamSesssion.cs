﻿using System;
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
            LoadGame();
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
            File.WriteAllText(@"c:/test/ludo.json", json);
        }

        static public List<LudoEngine> LoadGame()
        {
            if (File.Exists(@"c:/test/ludo.json"))
            {
                using (var r = new StreamReader(@"c:/test/ludo.json"))
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
            var gameList = GamSesssion.LoadGame();
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
            game.NextTurn();
            return game.MovePiece(pieceNr-1);
        }


        static public List<string> GameInfo()
        {
            List<string> returnList = new List<string>();
            game.NextTurn();
            foreach (var item in game.PlayersList[game.ActivePlayer].Pieces)
            {
                returnList.Add(game.NextTurn()[0]+","+game.NextTurn()[1]);
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
            return returnList;
        }
    }
}
