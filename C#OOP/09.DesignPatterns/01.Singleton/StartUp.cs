using System;

namespace SingletonDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Sofia"));
            Console.WriteLine(db2.GetPopulation("Sofia"));
            Console.WriteLine(db3.GetPopulation("Sofia"));
            Console.WriteLine(db4.GetPopulation("Sofia"));

        }
    }
}
