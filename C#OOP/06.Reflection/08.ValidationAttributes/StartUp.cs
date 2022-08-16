using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person("Pesho", 14);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
