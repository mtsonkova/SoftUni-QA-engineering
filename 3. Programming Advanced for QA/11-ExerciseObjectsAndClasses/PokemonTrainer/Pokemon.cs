using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public string name { get; set; }
        
        public string element { get; set; }

        public int health { get; set; }

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }
    }
}
