using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string currentBook = "";
            int checkedBooks = 0;
            while ((currentBook = Console.ReadLine())!=wantedBook)
            {
                if (currentBook == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!" +
                   $"{Environment.NewLine}You checked {checkedBooks} books.");
                    break;
                }

                checkedBooks++;
            }

            if (currentBook == wantedBook)
            {
                Console.WriteLine($"You checked {checkedBooks} books and found it.");
            }
        }
    }
}
