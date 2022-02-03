using System;
using System.Linq;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ",GetCharacters(firstSymbol,secondSymbol)));
        }

        static char[] GetCharacters(char firstSymbol, char secondSymbol)
        {
            char start;
            char end;

            if (firstSymbol > secondSymbol)
            {
                start = secondSymbol;
                end = firstSymbol;
            }
            else
            {
                start = firstSymbol;
                end = secondSymbol;
            }

            char[] characters = new char[end - (start + 1)];
            int counter = 0;

            for (int i = start + 1; i < end; i++)
            {
                characters[counter] = (char)i;
                counter++;
            }

            return characters;
        }
    }
}
