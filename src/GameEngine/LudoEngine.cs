using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class LudoEngine
    {
        public int Counter = 0;
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

        

        public bool MovePiece(int PieceNr)
        {
            Piece tempPiece = PlayersList[Counter].Pieces[PieceNr - 1];

            if (tempPiece.InNest)
            {
                PieceFromNest(PieceNr);
                return true;
            }
            else
            {
                if (tempPiece.Movement + LastDiceThrow >= 40)
                {
                    tempPiece.CompleteLap = true;   
                }
                int location = tempPiece.StartLocation + (tempPiece.Movement - 1);
                int nextLocation = location + LastDiceThrow;
                int finalStretchLocation = 0;
                bool newLap = false;

                if (location >= 40)
                {
                    location -= 40;
                }

                if (tempPiece.CompleteLap) //(tempPiece.Movement + LastDiceThrow >= 40)
                {

                    finalStretchLocation = ((tempPiece.Movement + LastDiceThrow) - 41);
                    FinalStretch[finalStretchLocation].AddPieceToTile(tempPiece);

                    for (int i = 0; i < TileList.Count && location <= 40; i++)
                    {
                        if (tempPiece.PlayerColor == TileList[location].PieceList[i].PlayerColor && tempPiece.PieceName == TileList[location].PieceList[i].PieceName)
                        {
                            TileList[location].PieceList.RemoveAt(i);
                            tempPiece.Movement += LastDiceThrow;

                            return true;
                        }
                    }

                    for (int i = 0; i < FinalStretch.Count; i++)
                    {
                        if (FinalStretch[finalStretchLocation].PieceList.Count > 0 && tempPiece.PlayerColor == FinalStretch[finalStretchLocation].PieceList[i].PlayerColor && tempPiece.PieceName == FinalStretch[finalStretchLocation].PieceList[i].PieceName)
                        {
                            FinalStretch[finalStretchLocation].PieceList.RemoveAt(i);
                            tempPiece.Movement += LastDiceThrow;


                            return true;
                        }
                    }
                }


                if (nextLocation > TileList.Count - 1 && !tempPiece.CompleteLap)
                {
                    nextLocation = nextLocation - TileList.Count;
                    newLap = true;
                }

                if (!TileList[nextLocation].Full)
                {
                    if (!newLap)
                    {
                        for (int i = location + 1; i <= nextLocation; i++)
                        {
                            if (TileList[i].Blocked)
                            {
                                if (LastDiceThrow != 6)
                                {
                                    Counter++;
                                }
                                TileStatus();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //Applied when completed a whole lap
                        for (int i = location + 1; i < TileList.Count; i++)
                        {
                            if (TileList[i].Blocked)
                            {
                                if (LastDiceThrow != 6)
                                {
                                    Counter++;
                                }
                                TileStatus();
                                return false;
                            }
                        }
                        for (int i = 0; i <= nextLocation; i++)
                        {
                            if (TileList[i].Blocked)
                            {
                                if (LastDiceThrow != 6)
                                {
                                    Counter++;
                                }
                                TileStatus();
                                return false;
                            }
                        }

                    }

                    

                    for (int i = 0; i < TileList[location].PieceList.Count; i++)
                    {
                        if (tempPiece.PlayerColor == TileList[location].PieceList[i].PlayerColor && tempPiece.PieceName == TileList[location].PieceList[i].PieceName)
                        {
                            TileList[location].PieceList.RemoveAt(i);
                        }
                    }

                    TileList[nextLocation].AddPieceToTile(tempPiece);

                }

                tempPiece.Movement += LastDiceThrow;

                if (LastDiceThrow != 6)
                {
                    Counter++;
                }

                TileStatus();
                return true;
            }
        }


        public string[] NextTurn()
        {
            string[] playerAndDice = new string[2];

            if (Counter == NrOfPlayer)
            {
                Counter = 0;
            }

            LastDiceThrow = 6;

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + LastDiceThrow;

            return playerAndDice;

        }

        private string[] PieceFromNest(int pieceNr)
        {
            string[] playerAndDice = new string[2];

            if (LastDiceThrow != 6)
            {
                playerAndDice[0] = PlayersList[Counter].Color;
                playerAndDice[1] = LastDiceThrow + " Piece can not move. Next Player";
                Counter++;
                TileStatus();
                return playerAndDice;
            }
            else if (LastDiceThrow == 6 && PlayersList[Counter].Pieces[pieceNr - 1].InNest)
            {
                PlayersList[Counter].Pieces[pieceNr - 1].Movement = 1;
                TileList[PlayersList[Counter].Pieces[pieceNr - 1].StartLocation].AddPieceToTile(PlayersList[Counter].Pieces[pieceNr - 1]);
            }

            playerAndDice[0] = PlayersList[Counter].Color;
            playerAndDice[1] = "" + LastDiceThrow;


            return playerAndDice;
        }

        public void SkipTurn()
        {
            Counter++;
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
    }
}
