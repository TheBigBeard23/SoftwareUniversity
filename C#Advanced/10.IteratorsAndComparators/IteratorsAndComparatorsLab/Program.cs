using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace"),
                new Book("Animal Farm", 2003, "George Orwell"),
                new Book("The Documents in the Case", 1930)
            };


            Library libraryTwo = new Library(books);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}
