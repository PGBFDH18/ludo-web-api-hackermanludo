using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackermanLudoApi.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Color { get; set; }


        public int UserId { get; set; }
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
