using System.Collections.Generic;
using System.Linq;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Implementation
{
    public class SuperHeroHandler : IHandler<Characters>
    {
        private IFileReader<string> _fileReader;
        private ISuperHeroesRule _superheroesRule;
        
        public SuperHeroHandler(IFileReader<string> fileReader, ISuperHeroesRule superHeroesRule)
        {
            _fileReader = fileReader;
            _superheroesRule = superHeroesRule;
        }

        public Characters ApplySorting() {
            var fileContents = GetFileContents();
            // Remove any duplicates in the file
            var duplicatesRemoved = fileContents.Distinct().ToList();
            var characters = SortSuperHeroes(duplicatesRemoved);
            return characters;
        }

        private List<string> GetFileContents() 
        {
            return _fileReader.ReadFromFile();
        }

        private Characters SortSuperHeroes(List<string> fileContents)
        {
            return _superheroesRule.ApplyRule(fileContents);
        }
    }
}
