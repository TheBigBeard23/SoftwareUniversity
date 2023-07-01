namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using System;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //  DbInitializer.ResetDatabase(dbContext);

        string command = Console.ReadLine();
        Console.WriteLine(GetBooksByAgeRestriction(dbContext, command));
    }

    public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
    {
        try
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var booksTitles = dbContext.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, booksTitles);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }
}



