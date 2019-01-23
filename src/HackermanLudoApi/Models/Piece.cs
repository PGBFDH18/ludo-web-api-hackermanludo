using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Piece
    {
        public int Id { get; set; }
        public int StartLocation { get; set; }
        public int Movement { get; set; }
        public bool InNest { get; set; }
        public int PieceName { get; set; }
        public string PlayerColor { get; set; }
        public bool CompleteLap { get; set; }
        public bool Finnished { get; set; }
        public int PlayerId { get; set; }
        public int? TileId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Tile Tile { get; set; }
    }
}
