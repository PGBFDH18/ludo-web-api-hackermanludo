﻿using System;
using GameEngine;
using HackermanLudoApi;


namespace TestOfEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            int loadGame = ReadInt("1: New game?\n2: Load game?");

            LudoEngine game;

            if (loadGame == 2)
            {
                HackermanLudoApi.Models.GamSesssion.ShowSavedGames();

                for (int i = 0; i < HackermanLudoApi.Models.GamSesssion.GameList.Count; i++)
                {
                    Console.WriteLine(i+": "+HackermanLudoApi.Models.GamSesssion.GameList[i].GameName);
                }
                int gameToLoad = ReadInt("What game to load?");
                game = HackermanLudoApi.Models.GamSesssion.GameList[gameToLoad];

            }
            else
            {

                int players = ReadInt("How many players?");
                game = new LudoEngine(players, ReadString("GameName?"));
            }



            while (true)
            {
                var result = game.NextTurn();

                PrintOutPieces(game, result[0]);
                var choice = ReadInt($"Player is: {result[0]}\nDice shows: {result[1]}\nWhat do You want to do?\n1: Move Piece?\n2: Pass turn?");

                if (choice == 1)
                {
                    int pieceNr = ReadInt("Wich piece do U wanna move?");
                    var actionFromEngine = game.MovePiece(pieceNr - 1);


                    Console.WriteLine(actionFromEngine[0] + actionFromEngine[1]);
                }
                else if (choice == 2)
                {
                    game.PassTurn();
                }


                if (1 == ReadInt("SaveGame?\n1:Yes\n2:No"))
                {
                    HackermanLudoApi.Models.GamSesssion.SaveGame(game);
                }
            }
        }

        static int ReadInt(string promt)
        {
            Console.WriteLine(promt);
            return int.Parse(Console.ReadLine());
        }

        static void PrintOutPieces(LudoEngine game, string playerColor)
        {
            foreach (var player in game.PlayersList)
            {
                if (player.Color == playerColor)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (player.Pieces[i].InNest == true)
                        {
                            Console.WriteLine($"Piece nr {i + 1} is in the nest");
                        }
                        else if (player.Pieces[i].Score)
                        {
                        }
                        else
                        {
                            Console.WriteLine($"Piece nr {i + 1} have moved {player.Pieces[i].Movement}");
                        }
                    }
                }
            }
            foreach (var item in game.TileList)
            {
                if (item.PieceList.Count > 0)
                {
                    Console.Write("On tile position " + item.TilePosition + " ");

                    for (int i = 0; i < item.PieceList.Count; i++)
                    {
                        Console.Write(item.PieceList[i].PlayerColor + " ");
                        Console.Write(item.PieceList[i].PieceName + ", ");
                    }
                    Console.WriteLine();
                }
            }
            foreach (var item in game.FinalStretch)
            {
                if (item.PieceList.Count > 0)
                {
                    Console.Write("On final tile position " + item.TilePosition + " ");

                    for (int i = 0; i < item.PieceList.Count; i++)
                    {
                        Console.Write(item.PieceList[i].PlayerColor + " ");
                        Console.Write(item.PieceList[i].PieceName + ", ");
                    }
                    Console.WriteLine();
                }

            }
        }

        static public string ReadString(string promt)
        {
            Console.WriteLine(promt);
            return Console.ReadLine();
        }
    }
}
