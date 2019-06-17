using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private IHandler<Characters> _superHeroesHandler;

        public SuperHeroesController(IHandler<Characters> superHeroesHandler) 
        {
            _superHeroesHandler = superHeroesHandler;
        }

        // GET api/superheroes
        [HttpGet]
        public ActionResult<Characters> Get()
        {
            var sortedCharacters = _superHeroesHandler.GetCharacters();
            return sortedCharacters;
        }

    }

}
