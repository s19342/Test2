using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test2.DTOs.Requests;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ChampionshipController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public IActionResult GetList(int id)
        {
            var ret = _dbService.GetTeams(id);

            if (ret == null)
            {
                return NotFound("championships with that id not found");
            }
 
            return Ok(ret);
        }

        [Route("/api/teams/{id}/players")]
        [HttpPost]

        public IActionResult AddPlayer(int id, PlayerRequest pr)
        {
            var ret = _dbService.AddplayerToTeam(id, pr);

            if(ret == 0)
            {
                return BadRequest("Age too high");
            }

            if(ret == 1)
            {
                return NotFound("Player does not exist");
            }

            if(ret == 2)
            {
                return BadRequest("Team already assigned");
            }

            return Ok("Player added to the team");
        }
    }
}