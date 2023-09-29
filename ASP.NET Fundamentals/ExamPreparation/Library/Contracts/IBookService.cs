using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBookViewModel>> GetMyBookAsync(string userId);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task RemoveFromCollectionAsync(string userId, BookViewModel book);

        Task<AddBookViewModel> GetNewAddBookViewModel();

        Task AddBookAsync(AddBookViewModel model);
    }
}
