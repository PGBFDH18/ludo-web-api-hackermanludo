using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackermanLudoApi.Models
{
    public class FiaService
    {
        public static List<Game> GettingGames()
        {

            var context = new FiaDBContext();
            return context.Game.ToList();
        }

        //Test method for get all players
        public static List<Player> GetPlayers()
        {
            var context = new FiaDBContext();
            return context.Player.ToList();
        }

    }
}
