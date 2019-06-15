using System;
using System.Collections.Generic;
using SuperHeroes.Models;

namespace SuperHeroes.Interfaces
{
    public interface ISuperHeroesRule
    {
        Characters ApplyRule(List<string> inputContents);
    }
}
