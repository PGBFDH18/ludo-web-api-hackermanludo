using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Tile
    {
        public int TilePosition;
        public List<Piece> PieceList;
        public bool Full;
        public bool Blocked;

        public Tile (int TilePos)
        {
            TilePosition = TilePos;
            PieceList = new List<Piece>();
        }

        public bool AddPieceToTile(Piece piece)
        {

            if (Full)
            {
                return false;
            }

            if(PieceList.Count < 2)
            {
                PieceList.Add(piece);

                if (piece.InNest)
                {
                    piece.InNest = false;
                }
            }

            if (PieceList.Count == 2)
            {
                Full = true;
                if (PieceList[0].PlayerColor == PieceList[1].PlayerColor)
                {
                    Blocked = true;
                }
                else
                {
                    Blocked = false;
                }
            }
            return true;
        }

       
    }
}
