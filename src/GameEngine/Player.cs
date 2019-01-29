using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Player
    {
        public string Color { get; set; }
        public List<Piece> Pieces { get; set; }

        public Player(int PlayerNumber)
        {
            string[] playerColor = new string[4] { "Blue", "Red", "Yellow", "Green" };
            int[] startPosition = new int[4] {0, 10, 20, 30 };

            Color = playerColor[PlayerNumber];


            Pieces = new List<Piece>();
            for (int i = 0; i < 4; i++)
            {
                Pieces.Add(new Piece(i+1, Color, startPosition[PlayerNumber]));
            }
        }
    }
}
