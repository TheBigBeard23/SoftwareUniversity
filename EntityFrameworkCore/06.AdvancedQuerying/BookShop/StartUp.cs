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

        string[] categories  = Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        Console.WriteLine(GetBooksByCategory(dbContext, categories));
    }

    //2. Age Restriction
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

    //3. Golden Books
    public static string GetGoldenBooks(BookShopContext dbContext)
    {
        var booksTitles = dbContext.Books
            .Where(b => b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, booksTitles);
    }

    //4. Books by Price
    public static string GetBooksByPrice(BookShopContext dbContext)
    {
        return String.Join(Environment.NewLine, dbContext.Books
                                                        .Where(b => b.Price > 40)
                                                        .OrderByDescending(b => b.Price)
                                                        .Select(b => $"{b.Title} - ${b.Price:f2}")
                                                        .ToArray());
    }

    //5. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        return String.Join(Environment.NewLine, context.Books
                                                      .Where(b => b.ReleaseDate.Value.Year != year)
                                                      .OrderBy(b => b.BookId)
                                                      .Select(b => b.Title)
                                                      .ToArray());
    }

    //6. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext dbContext, string[] categories)
    {
        return String.Join(Environment.NewLine, dbContext.BooksCategories
                                                         .Where(bc => categories.Contains(bc.Category.Name))
                                                         .Select(bc => bc.Book.Title)
                                                         .OrderBy(t => t)
                                                         .ToArray());

    }
}



