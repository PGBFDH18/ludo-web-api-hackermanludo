using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Player
    {
        public Player()
        {
            Pieces = new HashSet<Pieces>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Pieces> Pieces { get; set; }
    }
}
