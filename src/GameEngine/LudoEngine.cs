using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class LudoEngine
    {
        public int ActivePlayer = 0;
        private int LastDiceThrow { get; set; }
        private int nrOfPlayer;
        public bool OkToStart { get; set; }
        public int NrOfPlayer
        {
            get
            {
                return nrOfPlayer;
            }
            set
            {
                if (value < 2 || value > 4)
                {
                    OkToStart = false;
                }
                else
                {
                    OkToStart = true;
                    nrOfPlayer = value;
                }
            }
        }


        public List<Player> PlayersList { get; set; }

        public List<Tile> TileList { get; set; }
        public List<Tile> FinalStretch { get; set; }

        public LudoEngine(int numberOfPlayers)
        {
            NrOfPlayer = numberOfPlayers;
            if (OkToStart)
            {
                PlayersList = new List<Player>();
                FinalStretch = new List<Tile>();
                for (int i = 0; i < NrOfPlayer; i++)
                {
                    PlayersList.Add(new Player(i));

                }

                TileList = new List<Tile>();
                for (int i = 1; i <= 40; i++)
                {
                    TileList.Add(new Tile(i));
                }

                for (int i = 1; i <= 5; i++)
                {
                    FinalStretch.Add(new Tile(i));
                }
            }

        }


        public string[] NextTurn()
        {
            if (ActivePlayer >= PlayersList.Count)
            {
                ActivePlayer = 0;
            }
            //LastDiceThrow = Dice.ThrowDice();
            LastDiceThrow = 3;
            string[] playerAndDice = new string[]
            {
            PlayersList[ActivePlayer].Color, LastDiceThrow.ToString()
            };
            return playerAndDice;

        }

        public string[] MovePiece(int pieceNr)
        {
            var currentPlayer = PlayersList[ActivePlayer];
            var choosenPiece = currentPlayer.Pieces[pieceNr];

            // Move pieces out of nest.
            if (choosenPiece.InNest)
            {
                return PieceFromNest(choosenPiece, currentPlayer);
            }

            // Move pieces on the gameboard.
            if (choosenPiece.Movement + LastDiceThrow <= 40)
            {
                return MovePieceOnBoard(choosenPiece, currentPlayer);
            }

            // Move piece over to final stretch.

            return MovePieceOnFinal(choosenPiece, currentPlayer);




        }

        private string[] MovePieceOnFinal(Piece choosenPiece, Player currentPlayer)
        {
            var location = choosenPiece.StartLocation + choosenPiece.Movement;
            var nextLocation = (choosenPiece.Movement + LastDiceThrow) - 40;
            string[] playerAndDice = new string[] { currentPlayer.Color, "Piece has moved" };



            if (PieceFinished(choosenPiece, location))
            {
                var winner = new string[] { currentPlayer.Color, choosenPiece.PieceName + " Has entered the goal." };
                return winner;
            }

            // Move piece to the final stretch
            if (choosenPiece.Movement < 40)
            {
                TileList[location].RemovePieceFromTile(choosenPiece);
                FinalStretch[nextLocation].AddPieceToTile(choosenPiece);
                choosenPiece.Movement += LastDiceThrow;
                if (LastDiceThrow != 6)
                {
                    ActivePlayer++;
                }

                return playerAndDice;
            }

            // If piece already is on the final stretch
            if (choosenPiece.Movement >= 40)
            {
                location = choosenPiece.Movement - 40;
                if (nextLocation > FinalStretch.Count)
                {
                    int tempNextLoc = nextLocation - (FinalStretch.Count-1);
                    nextLocation = (FinalStretch.Count-1) - tempNextLoc;


                    //nextLocation = nextLocation - FinalStretch.Count;
                    FinalStretch[nextLocation].AddPieceToTile(choosenPiece);
                    FinalStretch[location].RemovePieceFromTile(choosenPiece);
                    choosenPiece.Movement = nextLocation+40;
                    if (LastDiceThrow != 6)
                    {
                        ActivePlayer++;
                    }

                    return playerAndDice;
                }
                FinalStretch[nextLocation].AddPieceToTile(choosenPiece);
                FinalStretch[location].RemovePieceFromTile(choosenPiece);
                return playerAndDice;

            }

            return playerAndDice;

        }
        private bool PieceFinished(Piece choosenPiece, int location)
        {
            if (choosenPiece.Movement + LastDiceThrow == 45)
            {
                choosenPiece.Score = true;
                if (LastDiceThrow != 6)
                {
                    ActivePlayer++;
                }
                FinalStretch[location-40].RemovePieceFromTile(choosenPiece);
                return true;
            }
            return false;
        }
        private string[] MovePieceOnBoard(Piece choosenPiece, Player currentPlayer)
        {
            var location = choosenPiece.StartLocation + choosenPiece.Movement;
            var nextLocation = location + LastDiceThrow;
            string[] playerAndDice = new string[] { currentPlayer.Color, "Piece has moved" };


            // If piece has passed location 1 but not completed a whole lap.
            if (nextLocation > TileList.Count)
            {
                nextLocation = nextLocation - TileList.Count;
                TileList[nextLocation].AddPieceToTile(choosenPiece);
                TileList[location].RemovePieceFromTile(choosenPiece);
                choosenPiece.Movement += LastDiceThrow;
                if (LastDiceThrow != 6)
                {
                    ActivePlayer++;
                }


                return playerAndDice;

            }

            // Move piece to next location.
            TileList[nextLocation].AddPieceToTile(choosenPiece);
            TileList[location].RemovePieceFromTile(choosenPiece);
            choosenPiece.Movement += LastDiceThrow;
            if (LastDiceThrow != 6)
            {
                ActivePlayer++;
            }

            return playerAndDice;

        }
        private string[] PieceFromNest(Piece choosenPiece, Player currentPlayer)
        {
            string[] playerAndDice = new string[2];

            if (LastDiceThrow != 6)
            {
                playerAndDice[0] = currentPlayer.Color;
                playerAndDice[1] = " That piece can not move. Next Player";
                ActivePlayer++;
                TileStatus();
                return playerAndDice;
            }
            else if (LastDiceThrow == 6)
            {
                choosenPiece.Movement = 0;
                TileList[choosenPiece.StartLocation].AddPieceToTile(choosenPiece);
            }

            playerAndDice[0] = currentPlayer.Color;
            playerAndDice[1] = "" + LastDiceThrow;

            return playerAndDice;
        }
        public void TileStatus()
        {
            foreach (var item in TileList)
            {
                if (item.PieceList.Count < 2)
                {
                    item.Blocked = false;
                    item.Full = false;
                }
            }
            foreach (var item in PlayersList)
            {
                int PiecesInGoal = 0;

                foreach (var piece in item.Pieces)
                {

                    if (piece.Score)
                    {
                        PiecesInGoal++;
                    }
                }
                if (PiecesInGoal == 4)
                {
                    Console.WriteLine($"{item.Color} wins!");
                }

            }
        }
        public void PassTurn()
        {
            ActivePlayer++;
        }
    }
}
