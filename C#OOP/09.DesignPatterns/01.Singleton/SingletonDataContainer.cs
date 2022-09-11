using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SingletonDemo
{
    public class SingletonDataContainer
    {
        private Dictionary<string, int> capitalsPopulation = new Dictionary<string, int>();

        private static SingletonDataContainer instance = new SingletonDataContainer();
        public static SingletonDataContainer Instance => instance;
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("../../../capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                capitalsPopulation.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return capitalsPopulation[name];
        }
    }
}
