using System;
using System.Collections.Generic;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Implementation
{
    public class ContainsDRule : ISuperHeroesRule
    {
        public Characters ApplyRule(List<string> inputContents)
        {
            var characters = new Characters();
            foreach(var input in inputContents) 
            {
                if (input.Contains('D')) 
                {
                    characters.Villains.Add(input);
                }
                else 
                {
                    characters.Superheroes.Add(input);
                }
            }
            return characters;
        }
    }
}
