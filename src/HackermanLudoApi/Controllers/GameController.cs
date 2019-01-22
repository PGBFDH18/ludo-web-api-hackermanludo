﻿using System;
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
        [HttpGet]
        public List<Game> Get()
        {
            return FiaService.GettingGames();
        }

       
    }
}
