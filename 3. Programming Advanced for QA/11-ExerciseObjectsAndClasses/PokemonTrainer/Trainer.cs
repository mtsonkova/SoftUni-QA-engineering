using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string name { get; set; }
        public int numberOfBadges { get; set; }
        public List<Pokemon> pokemons { get; set; }

        public Trainer(string name)
        {
            this.name = name;
            this.numberOfBadges = 0;
            pokemons = new List<Pokemon>();
        }
    }
}
