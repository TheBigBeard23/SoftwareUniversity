using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(5, "Pesho");

            Console.WriteLine(string.Join(",",array));
        }
    }
}
