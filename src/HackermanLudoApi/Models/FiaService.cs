using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HackermanLudoApi.Models
{
    public class FiaService
    {
        public static List<Game> GettingGames()
        {

            var context = new FiaDBContext();

            var inludingPlayers = context.Game.Include(g => g.Players).ToList();

            return inludingPlayers;
            
        }

        public static List<Player> GettingPlayer()
        {
            var context = new FiaDBContext();

            return context.Player.ToList();
        }

    }
}
