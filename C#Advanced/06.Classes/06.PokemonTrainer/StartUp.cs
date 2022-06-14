using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealt = int.Parse(data[3]);

                var trainer = trainers.Where(x => x.Name == trainerName).FirstOrDefault();
                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealt));
            }

            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Where(x => x.Pokemons.Any(p => p.Element == element)))
                {
                    trainer.BadgesCount++;
                }
                foreach (var trainer in trainers.Where(x => x.Pokemons.Any(p => p.Element == element) == false))
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.ReduceHealt();
                    }
                    trainer.CheckPokemonHealt();
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
