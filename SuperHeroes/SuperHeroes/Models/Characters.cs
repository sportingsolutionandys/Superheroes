using System;
using System.Collections.Generic;

namespace SuperHeroes.Models
{
    /// <summary>
    /// Characters - made up of lists of Superheroes and Villains
    /// </summary>
    public class Characters
    {
        public List<string> Superheroes { get; set; }
        public List<string> Villains { get; set; }

        public Characters()
        {
            Superheroes = new List<string>();
            Villains = new List<string>();

        }
    }
}
