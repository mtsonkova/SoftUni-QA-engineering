using System.Runtime.CompilerServices;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            // get list of trainers and their pokemons
            string userInput = Console.ReadLine();
            List<Trainer> pokemonTrainers = new List<Trainer>();

            while (userInput != "Tournament")
            {
                string[] info = userInput.Split(" ");
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                bool hasTrainer = pokemonTrainers.Any(trainer => trainer.name == trainerName);

                if (hasTrainer == true)
                {
                    Trainer currentTrainer = pokemonTrainers.Find(trainer => trainer.name.Equals(trainerName));
                    currentTrainer.pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.pokemons.Add(pokemon);
                    pokemonTrainers.Add(trainer);
                }
                userInput = Console.ReadLine();
            }

            string command = Console.ReadLine();

            // start pokemon tournament
            while(command != "End")
            {
                foreach(Trainer trainer in pokemonTrainers)
                {
                    bool hasElement = trainer.pokemons.Any(pokemon => pokemon.element.Equals(command));

                    if(hasElement)
                    {
                        trainer.numberOfBadges++;
                    }
                    else
                    {
                        foreach(Pokemon pokemon in trainer.pokemons)
                        {
                            pokemon.health -= 10;                           
                        }

                        trainer.pokemons = trainer.pokemons.FindAll(pokemon => pokemon.health > 0);
                    }
                }
                command = Console.ReadLine();
            }

            //print results from pokemon tournament

            var sortedTrainers = pokemonTrainers.OrderByDescending(trainer => trainer.numberOfBadges);
            foreach(Trainer trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.name} {trainer.numberOfBadges} {trainer.pokemons.Count}");
            }

        }
    }
}

