using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Tile
    {
        public Tile()
        {
            TilePieces = new HashSet<Piece>();
        }

        public int Id { get; set; }
        public int TilePosition { get; set; }
        public bool Full { get; set; }
        public bool Blocked { get; set; }

        public virtual ICollection<Piece> TilePieces { get; set; }
    }
}
