using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Characters> Get()
        {
            var sortedCharacters = _superHeroesHandler.GetCharacters();

            //If there was an issue reading from the file and no characters returned then dispatch NotFound
            if (sortedCharacters.Villains.Count == 0 && sortedCharacters.Superheroes.Count == 0)
                return NotFound();
            //Otherwise return characters
            return sortedCharacters;
        }

    }

}
