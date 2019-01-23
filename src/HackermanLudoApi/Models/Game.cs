using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackermanLudoApi.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }

    }
}
