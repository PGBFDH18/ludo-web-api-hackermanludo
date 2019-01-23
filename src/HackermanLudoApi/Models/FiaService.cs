using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HackermanLudoApi.Models
{
    public class FiaService
    {
        public static List<Game> GettingGame(int id)
        {

            using (var context = new FiaDBContext())
            {
                var includingAll = context.Game.Where(g => g.Id == id)
                    .Include(p => p.Player)
                    .ThenInclude(piece => piece.Piece)
                    .ThenInclude(tile => tile.Tile)
                    .ToList();

                return includingAll;
            }
        }

        public static void SaveToDb()
        {
            using(var context = new FiaDBContext())
            {

            }
        }

    }
}
