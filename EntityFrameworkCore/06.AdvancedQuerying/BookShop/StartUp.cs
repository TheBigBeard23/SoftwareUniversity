namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //  DbInitializer.ResetDatabase(dbContext);


        string input = Console.ReadLine();
        Console.WriteLine(GetBooksByAuthor(dbContext, input));
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
    public static string GetBooksNotReleasedIn(BookShopContext dbContext, int year)
    {
        return String.Join(Environment.NewLine, dbContext.Books
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

    //7. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext dbContext, string date)
    {
        DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        return String.Join(Environment.NewLine, dbContext.Books
                                                        .Where(b => EF.Functions.DateDiffDay(b.ReleaseDate, inputDate) > 0)
                                                        .OrderByDescending(b => b.ReleaseDate)
                                                        .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}")
                                                        .ToArray());
    }

    //8. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext dbContext, string input)
    {
        return String.Join(Environment.NewLine, dbContext.Authors
                                                         .Where(a => a.FirstName.EndsWith(input))
                                                         .OrderBy(a => a.FirstName)
                                                         .ThenBy(a => a.LastName)
                                                         .Select(a => $"{a.FirstName} {a.LastName}")
                                                         .ToArray());
    }

    //9. Book Search
    public static string GetBookTitlesContaining(BookShopContext dbContext, string input)
    {
        return String.Join(Environment.NewLine, dbContext.Books
                                                      .Where(b => b.Title.Contains(input.ToLower()))
                                                      .Select(b => b.Title)
                                                      .OrderBy(t => t)
                                                      .ToArray());
    }

    //10. Book Search By Author
    public static string GetBooksByAuthor(BookShopContext dbContext, string input)
    {
        return String.Join(Environment.NewLine, dbContext.Books
                                                        .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                                                        .OrderBy(b => b.BookId)
                                                        .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                                                        .ToArray());
    }
}



