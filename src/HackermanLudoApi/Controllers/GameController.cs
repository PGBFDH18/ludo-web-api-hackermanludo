using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HackermanLudoApi.Models;

namespace HackermanLudoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/Game
        [HttpGet("{id}")]
        public List<Game> Get(int id)
        {
            return FiaService.GettingGames(id);
        }

       
    }
}
