using System;
using System.Collections.Generic;
using SuperHeroes.Models;

namespace SuperHeroes.Interfaces
{
    /// <summary>
    /// Super heroes rule interface.
    /// </summary>
    public interface ISuperHeroesRule
    {
        Characters ApplyRule(List<string> inputContents);
    }
}
