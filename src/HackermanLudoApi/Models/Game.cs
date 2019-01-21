﻿using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Game
    {
        public Game()
        {
            Player = new HashSet<Player>();
        }

        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
