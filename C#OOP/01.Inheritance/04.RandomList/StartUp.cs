using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            for (int i = 1; i <= 10; i++)
            {
                list.Add(i.ToString());
            }

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
