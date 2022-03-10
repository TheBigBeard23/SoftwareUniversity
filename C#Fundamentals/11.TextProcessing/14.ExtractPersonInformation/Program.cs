using System;
using System.Collections.Generic;

namespace _14.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> nameAges = new Dictionary<string, int>();

            while (n>0)
            {
                string input = Console.ReadLine();

                string name = ExtractName(input);
                int age = int.Parse(ExtractAge(input));

                nameAges.Add(name, age);

                n--;
            }

            foreach (var name in nameAges)
            {
                Console.WriteLine($"{name.Key} is {name.Value} years old.");
            }
        }
        static string ExtractName(string text)
        {
            int index = text.IndexOf('@') + 1;
            string name = string.Empty;

            while (text[index] !='|')
            {
                name += text[index];
                index++;
            }

            return name;
        }
        static string ExtractAge(string text)
        {
            int index = text.IndexOf('#') + 1;
            string age = string.Empty;

            while (text[index] != '*')
            {
                age += text[index];
                index++;
            }

            return age;
        }
    }
}
