using System;

namespace PrototypeDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            Sandwich sandwichBLT = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwichPBJ = sandwichMenu["PB&J"].Clone() as Sandwich;
            Sandwich sandwichTurkey = sandwichMenu["Turkey"].Clone() as Sandwich;
        }
    }
}
