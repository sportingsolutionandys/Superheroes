using System.Collections.Generic;
using System.Linq;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Implementation
{
    public class SuperHeroesHandler : IHandler<Characters>
    {
        private IFileReader<string> _fileReader;
        private ISuperHeroesRule _superheroesRule;
        private Characters _characters;
        
        public SuperHeroesHandler(IFileReader<string> fileReader, ISuperHeroesRule superHeroesRule)
        {
            _fileReader = fileReader;
            _superheroesRule = superHeroesRule;
        }

        public Characters GetCharacters() {
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

        public List<string> RemoveDuplicatesFromList(List<string> fileContents) 
        {
            return fileContents.Distinct().ToList();
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
