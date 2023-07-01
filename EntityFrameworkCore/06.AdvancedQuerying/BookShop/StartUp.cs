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

        var titles = GetGoldenBooks(dbContext);
        Console.WriteLine(titles);
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

    public static string GetGoldenBooks(BookShopContext dbContext)
    {
        var booksTitles = dbContext.Books
            .Where(b => b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, booksTitles);
    }
}



