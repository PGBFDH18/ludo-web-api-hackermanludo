using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Tile
    {
        public int Id { get; set; }
        public int TilePosition { get; set; }
        public bool Full { get; set; }
        public bool Blocked { get; set; }
        public int PieceId { get; set; }
    }
}
