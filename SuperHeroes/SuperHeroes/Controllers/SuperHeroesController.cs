using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private readonly IHandler<Characters> _superHeroesHandler;
        private readonly ILogger _logger;

        public SuperHeroesController(IHandler<Characters> superHeroesHandler, ILogger<SuperHeroesController> logger) 
        {
            _superHeroesHandler = superHeroesHandler;
            _logger = logger;
        }

        // GET api/superheroes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Characters> Get()
        {
            //Get sorted characters
            var sortedCharacters = _superHeroesHandler.GetCharacters();

            //If there was an issue reading from the file and no characters returned then dispatch NotFound
            if (sortedCharacters.Villains.Count == 0 && sortedCharacters.Superheroes.Count == 0) 
            {
                _logger.LogInformation("Making call to get superheroes didn't return any characters. Check the log for possible errors");
                return NotFound();
            }

            //Otherwise return characters
            return sortedCharacters;
        }

    }

}
