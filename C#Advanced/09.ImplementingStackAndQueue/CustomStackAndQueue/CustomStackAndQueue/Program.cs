using System;

namespace CustomStackAndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            for (int i = 1; i <= 8; i++)
            {
                list.Add(i);
            }

            var reversedList = list.Reverse();

            Console.WriteLine(list);
            Console.WriteLine(reversedList);
        }
    }
}
