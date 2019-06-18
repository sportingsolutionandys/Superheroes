using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SuperHeroes.Interfaces;
using SuperHeroes.Models;

namespace SuperHeroes.Implementation
{
    /// <summary>
    /// Contains DRule.
    /// Specific implementaion of rule to have Villains if the contain a 'D' in their name
    /// </summary>
    public class ContainsDRule : ISuperHeroesRule
    {
        private readonly ILogger _logger;

        public ContainsDRule(ILogger<ContainsDRule> logger) 
        {
            _logger = logger;
        }

        /// <summary>
        /// Applies the contains D rule.
        /// </summary>
        /// <returns>The rule.</returns>
        /// <param name="inputContents">Input contents.</param>
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
            _logger.LogInformation("Contains D rule was successfully implemented.");
            return characters;
        }
    }
}
