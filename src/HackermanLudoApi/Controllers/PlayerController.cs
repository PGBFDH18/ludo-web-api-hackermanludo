using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackermanLudoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HackermanLudoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public List<Player> Get()
        {
            return FiaService.GettingPlayer();
        }
    }
}