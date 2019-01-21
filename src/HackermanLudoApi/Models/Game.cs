using System;
using System.Collections.Generic;

namespace HackermanLudoApi.Models
{
    public partial class Game
    {
        public Game()
        {
            var context = new FiaDBContext();
             
            Player = new HashSet<Player>(context.Player);
        }

        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Player { get; set; }
    }
}
