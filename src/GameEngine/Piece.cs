using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Piece
    {

        public int StartLocation  { get; set; }
        public int Movement { get; set; }
        public bool InNest { get; set; }
        public int PieceName { get; set; }
        public string PlayerColor { get; set; }
        public bool CompleteLap { get; set; }
        public bool Score { get; set; }

        public Piece(int pieceNr, string color, int startPosition)
        {
            Movement = 0;
            InNest = true;
            PieceName = pieceNr;
            PlayerColor = color;
            StartLocation = startPosition;
            CompleteLap = false;
            Score = false;
        }

        public void MovePiece(int diceValue)
        {
            Movement += diceValue;
        }

    }
}
