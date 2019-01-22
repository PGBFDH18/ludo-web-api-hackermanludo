using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}
