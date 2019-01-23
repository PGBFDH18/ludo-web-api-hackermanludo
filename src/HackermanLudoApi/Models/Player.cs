using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Player
    {
        public Player()
        {
            Piece = new HashSet<Piece>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Piece> Piece { get; set; }
    }
}
