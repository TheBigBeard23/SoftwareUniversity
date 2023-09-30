using Library.Contracts;
using Library.Data;
using Library.Data.Model;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;

        public BookService(LibraryDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<AddBookViewModel> GetNewAddBookViewModel()
        {
            AddBookViewModel viewModel = new AddBookViewModel()
            {
                Categories = await _dbContext.Categories
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToListAsync()
            };

            return viewModel;
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await _dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                IdentityUserBook userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                };

                await _dbContext.IdentityUserBooks.AddAsync(userBook);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this._dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMyBookAsync(string userId)
        {
            return await _dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                }).ToListAsync();

        }

        public async Task RemoveFromCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await _dbContext.IdentityUserBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (userBook != null)
            {
                _dbContext.IdentityUserBooks.Remove(userBook);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating)
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();


        }

        public async Task<bool> DeleteBook(int id)
        {
            Book? book = await _dbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();

            if (book == null)
            {
                return false;
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
