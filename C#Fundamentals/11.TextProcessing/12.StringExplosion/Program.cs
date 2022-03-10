using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToList();
            int power = 0;

            for (int i = 0; i < text.Count; i++)
            {

                if (text[i] != '>' && power > 0)
                {
                    text.RemoveAt(i);
                    i--;
                    power--;
                }
                else if (text[i] == '>')
                {
                    power += int.Parse(text[i + 1].ToString());
                }
            }

            Console.WriteLine(string.Join("",text));
        }

        
    }
}
