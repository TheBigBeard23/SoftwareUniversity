using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.PokemonTrainer
{
   public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            BadgesCount = 0;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public void CheckPokemonHealt()
        {
            Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }
}
