using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Implementation
{
    /// <summary>
    /// Super heroes handler.
    /// This class acts as carrying out series of actions
    /// to read from file,
    /// remove any duplicates
    /// and apply specified rule
    /// </summary>
    public class SuperHeroesHandler : IHandler<Characters>
    {
        private readonly IFileReader<string> _fileReader;
        private readonly ISuperHeroesRule _superheroesRule;
        private readonly ILogger _logger;
        private Characters _characters;
        
        public SuperHeroesHandler(IFileReader<string> fileReader, 
            ISuperHeroesRule superHeroesRule, 
            ILogger<SuperHeroesHandler> logger)
        {
            _fileReader = fileReader;
            _superheroesRule = superHeroesRule;
            _logger = logger;
        }

        /// <summary>
        /// Gets the superhero characters.
        /// </summary>
        /// <returns>The characters.</returns>
        public Characters GetCharacters() {
            //Check to see if characters have already been populated
            if (_characters == null) 
            {
                //Read contents of file
                var fileContents = GetFileContents();
                // Remove any duplicates in the file
                var duplicatesRemoved = RemoveDuplicatesFromList(fileContents);
                //Sort based on rule
                _characters = SortSuperHeroes(duplicatesRemoved);
            }
            return _characters;
        }

        /// <summary>
        /// Gets the file contents.
        /// </summary>
        /// <returns>The file contents.</returns>
        private List<string> GetFileContents()
        {
            _logger.LogInformation("Reading from data file");
            return _fileReader.ReadFromFile();
        }

        /// <summary>
        /// Removes the duplicates from list.
        /// </summary>
        /// <returns>The duplicates from list.</returns>
        /// <param name="fileContents">File contents.</param>
        public List<string> RemoveDuplicatesFromList(List<string> fileContents) 
        {
            _logger.LogInformation("Removing duplicates from list.");
            return fileContents.Distinct().ToList();
        }


        /// <summary>
        /// Sorts the super heroes based on the rule.
        /// </summary>
        /// <returns>The super heroes characters</returns>
        /// <param name="fileContents">File contents.</param>
        private Characters SortSuperHeroes(List<string> fileContents)
        {
            _logger.LogInformation("Applying superhero rule.");
            return _superheroesRule.ApplyRule(fileContents);
        }
    }
}
