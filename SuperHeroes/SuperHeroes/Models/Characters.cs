using System;
using System.Collections.Generic;

namespace SuperHeroes.Models
{
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
