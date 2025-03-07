using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesTracker.Data;
using GamesTracker.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesTracker.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public GameController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _context.games.ToList().Select(s => s.ToGameDto());
            return Ok(games);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetByAppid([FromRoute] int id)
        {
            var game = _context.games.Find(id);

            return game == null ? NotFound() : Ok(game.ToGameDto());
        }
    }
}